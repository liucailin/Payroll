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
	}
}

