using System;
using Payroll;
using NUnit.Framework;

namespace Payroll.Test
{
	[TestFixture]
	public class RealPayrollDatabaseTest
	{
		PayrollDatabase database;

		[SetUp]
		public void SetUp()
		{
			database = new RealPayrollDatabase();
		}

		[Test]
		public void AddEmployee()
		{

		}
	}
}

