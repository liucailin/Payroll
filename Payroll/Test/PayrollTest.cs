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
			Assert.AreEqual(9.5f, (e.Classification as HourlyClassification).Hourly, .001);
		}

		[Test]
		public void TestAddCommissionedEmployee()
		{
			int empId = 3;
			AddEmployeeTransaction t = new AddCommissiondEmployee(empId, "Jack", "home", 0.1f);
			t.Execute();

			Employee e = PayrollDatabase.GetEmployee(empId);
			Assert.AreEqual("Jack", e.Name);
			
			Assert.IsTrue(e.Classification is CommissionClassification);
			Assert.IsTrue(e.Schedule is BiweeklySchedule);
			Assert.AreEqual(0.1f, (e.Classification as CommissionClassification).Percent, .001);
		}
	}
}

