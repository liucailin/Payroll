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
			AddEmployeeTransaction t = new AddHourlyEmployee(empId, "Lucy", "home", 100, 9.5f);
			t.Execute();

			Employee e = PayrollDatabase.GetEmployee(empId);
			Assert.AreEqual("Lucy", e.Name);

			Assert.IsTrue(e.Classification is HourlyClassification);
			Assert.IsTrue(e.Schedule is WeeklySchedule);
			Assert.AreEqual(9.5f, (e.Classification as HourlyClassification).Hours, .001);
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

			AddEmployeeTransaction t = new AddHourlyEmployee(empId, "Lucy", "home", 100, 9.5f);
			t.Execute();

			TimeCardTransaction t1 = new TimeCardTransaction(DateTime.Today, 9, empId);
			t1.Execute();

			Employee e = PayrollDatabase.GetEmployee(empId);
			Assert.IsNotNull(e);

			HourlyClassification pc = e.Classification as HourlyClassification;
			Assert.IsNotNull(pc);
			Assert.IsNotNull(pc.GetTimeCard(DateTime.Today));


			Assert.AreEqual(9.5f, pc.Hours); 

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

            AddEmployeeTransaction t = new AddHourlyEmployee(empid, "Lily", "Home", 200, 9);
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
            AddEmployeeTransaction ae = new AddHourlyEmployee(empid, "ho", "home", 100, 4);
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
            AddEmployeeTransaction ae = new AddHourlyEmployee(empid, "ho", "home", 100, 4);
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

       
    }
}

