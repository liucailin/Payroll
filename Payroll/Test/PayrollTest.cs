using System;
using NUnit.Core;
using NUnit.Framework;
namespace Payroll.Test
{

	public class PayrollTest
	{
		[Test]
		public void TestAddSalariedEmployee ()
		{
			int empId = 1;
			AddSalariedEmployee t = new AddSalariedEmployee(empId, "Bob", "home", 1000.00);
			t.Execute();

			Employee e = PayrollDatabase.GetEmployee(empId);
			Assert.AreEqual("Bob", e.Name);

			PaymentClassification pc = e.Classification;
			Assert.IsTrue(pc is SalariedClassification);
			SalariedClassification sc = pc as SalariedClassification;

			Assert.AreEqual(1000.00, sc.Salary, .001);
			PaymentSchedule ps = e.Schedule;
			Assert.IsTrue(ps is MonthlySchedule);

			PaymentMethod pm = e.Method;
			Assert.IsTrue(pm is HoldMethod);
		}


		[Test]
		public void TestAddHourlyEmployee ()
		{
			int empId = 2;
			AddEmployeeTransaction t = new AddHourlyEmployee(empId, "Lucy", "home", 9.5f);
			t.Execute();

			Employee e = PayrollDatabase.GetEmployee(empId);
			Assert.AreEqual("Lucy", e.Name);

			Assert.IsTrue(e.Classification is HourlyClassification);
			Assert.IsTrue(e.Schedule is WeeklySchedule);
			Assert.AreEqual(9.5f, (e.Classification as HourlyClassification).HourlyRate, .001);
		}

		[Test]
		public void TestAddCommissionedEmployee()
		{
			int empId = 3;
			AddEmployeeTransaction t = new AddCommissiondEmployee(empId, "Jack", "home", 2500, 0.1f);
			t.Execute();

			Employee e = PayrollDatabase.GetEmployee(empId);
			Assert.AreEqual("Jack", e.Name);
			
			Assert.IsTrue(e.Classification is CommissionClassification);
			Assert.IsTrue(e.Schedule is BiweeklySchedule);
			Assert.AreEqual(0.1f, (e.Classification as CommissionClassification).Percent, .001);
		}

		[Test]
		public void DeleteEmployee()
		{
			int empId = 3;
			AddEmployeeTransaction t = new AddCommissiondEmployee(empId, "Jack", "home", 2500, 0.1f);
			t.Execute();
			
			Employee e = PayrollDatabase.GetEmployee(empId);
			Assert.IsNotNull(e);

			new DeleteEmployeeTransaction(empId).Execute();

			e = PayrollDatabase.GetEmployee(empId);
			Assert.IsNull(e);
		}

		[Test]
		public void TestTimeCard()
		{
			int empId = 4;

			AddEmployeeTransaction t = new AddHourlyEmployee(empId, "Lucy", "home", 9.5f);
			t.Execute();

			TimeCardTransaction t1 = new TimeCardTransaction(DateTime.Today, 9, empId);
			t1.Execute();

			Employee e = PayrollDatabase.GetEmployee(empId);
			Assert.IsNotNull(e);

			HourlyClassification pc = e.Classification as HourlyClassification;
			Assert.IsNotNull(pc);
			Assert.IsNotNull(pc.GetTimeCard(DateTime.Today));


			Assert.AreEqual(9.5f, pc.HourlyRate); 

		}

		[Test]
		public void TestSalesReceiptTranscation() 
		{
			int empid = 5;

			AddEmployeeTransaction t = new AddCommissiondEmployee(empid, "Bill", "Home", 3000, 0.1f);
			t.Execute();

			SalesReceiptTransaction t1 = new SalesReceiptTransaction(DateTime.Now, 112, empid);
			t1.Execute();

			Employee e = PayrollDatabase.GetEmployee(empid);

			Assert.IsNotNull(e);

			CommissionClassification cc = e.Classification as CommissionClassification;

			Assert.IsNotNull(cc);

			SalesReceipt s = cc.GetSalesReceipt(DateTime.Now);
			Assert.IsNotNull(s);

			Assert.AreEqual(112, s.SaleAmount);
		}

        [Test]
        public void AddServiceCharge()
        {
            int empid = 6;

            AddEmployeeTransaction t = new AddHourlyEmployee(empid, "Lily", "Home", 9);
            t.Execute();

            Employee e = PayrollDatabase.GetEmployee((empid));

            Assert.IsNotNull(e);

            UnionAffiliation ua = new UnionAffiliation();
            e.Affiliation = ua;

            int unionMemberid = 444;
            PayrollDatabase.AddUnionMember(unionMemberid, e);

            SeriveChargeTransaction sct = new SeriveChargeTransaction(DateTime.Now, 111, unionMemberid);
            sct.Execute();

            ServiceCharge sc = ua.GetServiceCharge(DateTime.Now);
            Assert.AreEqual(111, sc.ChargeAmount);

        }

        [Test]
        public void ChangeNameTransaction()
        {
            int empid = 7;
            AddEmployeeTransaction ae = new AddHourlyEmployee(empid, "ho", "home", 4);
            ae.Execute();
            Employee e = PayrollDatabase.GetEmployee(empid);
            Assert.IsNotNull((e));

            ChangeNameTransaction ct = new ChangeNameTransaction(empid, "dada");
            ct.Execute();

            Employee e1 = PayrollDatabase.GetEmployee(empid);
            Assert.IsNotNull((e1));

            Assert.AreEqual("dada", e1.Name);


        }

        [Test]
        public void ChangeAddressTransaction()
        {
            int empid = 7;
            AddEmployeeTransaction ae = new AddHourlyEmployee(empid, "ho", "home", 4);
            ae.Execute();
            Employee e = PayrollDatabase.GetEmployee(empid);
            Assert.IsNotNull((e));

            ChangeAddressTransaction ct = new ChangeAddressTransaction(empid, "home1");
            ct.Execute();

            Employee e1 = PayrollDatabase.GetEmployee(empid);
            Assert.IsNotNull((e1));

            Assert.AreEqual("home1", e1.Address);
        }

        [Test]
        public void TestChangeHourlyClassificaiton()
        {
            int empid = 5;

            AddEmployeeTransaction t = new AddCommissiondEmployee(empid, "Bill", "Home", 3000, 0.1f);
            t.Execute();

         
            Employee e = PayrollDatabase.GetEmployee(empid);

            Assert.IsNotNull(e);

            ChangeHourlyClassification ct = new ChangeHourlyClassification(empid, 5);
            ct.Execute();

            Assert.IsTrue(e.Classification is HourlyClassification);
            Assert.IsTrue(e.Schedule is WeeklySchedule);

         
        }

        [Test]
        public void TestChangeUnionMember()
        {
            int empId = 8; AddHourlyEmployee t =
                new AddHourlyEmployee(empId, "Bill", "Home", 3 ); t.Execute();
            int memberId = 7743;
            ChangeMemberTransaction cmt =
                new ChangeMemberTransaction(empId, memberId, 99.42f); cmt.Execute();
            Employee e = PayrollDatabase.GetEmployee(empId); Assert.IsNotNull(e);
            Affiliation affiliation = e.Affiliation; 
            Assert.IsNotNull(affiliation); 
            Assert.IsTrue(affiliation is UnionAffiliation); 
            UnionAffiliation uf = affiliation as UnionAffiliation; 
            Assert.AreEqual(99.42, uf.Dues, .001);
            Employee member =PayrollDatabase.GetUnionMember(memberId); Assert.IsNotNull(member);
            Assert.AreEqual(e, member);
        }

        [Test]
        public void PaySingleSalariedEmployee()
        {
            int empId = 1;
            AddSalariedEmployee t = new AddSalariedEmployee(empId, "Bob", "home", 1000.00);
            t.Execute();

            Employee e = PayrollDatabase.GetEmployee(empId);
            Assert.AreEqual("Bob", e.Name);

            PaydayTransaction pt = new PaydayTransaction(new DateTime(2014, 11, 30));
            pt.Execute();

            Paycheck pc = pt.GetPaycheck(empId);

            Assert.IsNotNull(pc);
            Assert.AreEqual(1000.00, pc.GrossPay, .001);
            Assert.AreEqual(0, pc.Deductions, .001);
            Assert.AreEqual(1000.00, pc.NetPay, .001);
            Assert.AreEqual(new DateTime(2014, 11, 30), pc.PayEndDate);
        }

		[Test]
		public void payingSingleHourlyEmployeeNoTimeCard()
		{
			int empid = 2;
			AddHourlyEmployee t = new AddHourlyEmployee(empid, "Bill", "Home", 15.25);
			t.Execute();

			DateTime payDate = new DateTime(2014, 11, 7);
			PaydayTransaction pt = new PaydayTransaction(payDate);
			pt.Execute();


		}

		private void ValidateHourlyPayCheck(PaydayTransaction pt, int empid, DateTime payDate, double pay)
		{
			Paycheck pc = pt.GetPaycheck(empid);
			Assert.IsNotNull(pc);
			
			Assert.AreEqual(pay, pc.NetPay, 0.001);
			Assert.AreEqual(pay, pc.GrossPay, 0.001);
			Assert.AreEqual(0, pc.Deductions, 0.001);
			Assert.AreEqual(payDate, pc.PayEndDate);
		}

		[Test]
		public void PaySingleHourlyEmployeeOneTimeCard()
		{
			int empid = 2;
			AddHourlyEmployee t = new AddHourlyEmployee(empid, "Bill", "Home",  6);
			t.Execute();

			DateTime payDate = new DateTime(2014, 11, 7);

			TimeCardTransaction tc = new TimeCardTransaction(payDate, 6, empid);
			tc.Execute();


			PaydayTransaction pt = new PaydayTransaction(payDate);
			pt.Execute();

			ValidateHourlyPayCheck(pt, empid, payDate, 6 * 6);
		}

		[Test]
		public void PaySingleHourlyEmployeeOverTimeOneCard()
		{
			PayrollTestAddEmployee.AddHourlyEmployee(1, "Lily", "home", 9);
			DateTime payDate = new DateTime(2014, 11, 7);

			TimeCardTransaction tc = new TimeCardTransaction(payDate, 9.5, 1);
			tc.Execute();

			PaydayTransaction pt = new PaydayTransaction(payDate);
			pt.Execute();

			ValidateHourlyPayCheck(pt, 1, payDate, 8 * 9 + 1.5 * 9 * 1.5);
		}

		[Test]
		public void PayCommissionEmployee()
		{
			int empid = 1;
			PayrollTestAddEmployee.AddCommissiondEmployee(empid, "c", "h", 2000, 0.1);

			DateTime payDate = new DateTime(2014, 11, 7);
			DateTime saleDate = new DateTime(2014, 11, 2);
			SalesReceiptTransaction sr = new SalesReceiptTransaction(saleDate, 100, empid);
			sr.Execute();

			PaydayTransaction pt = new PaydayTransaction(payDate);
			pt.Execute();

			Paycheck pc = pt.GetPaycheck(empid);
			Assert.IsNotNull(pc);

			Assert.AreEqual(2000 + 100 * 0.1, pc.NetPay);

		} 

       
    }
}

