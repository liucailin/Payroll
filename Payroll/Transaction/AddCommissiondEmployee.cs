using System;
using NUnit.Core;
using NUnit.Framework;

namespace Payroll.Test
{
	class AddCommissiondEmployee : AddEmployeeTransaction
	{
		private readonly double percent;
		private readonly double salary;

		public AddCommissiondEmployee (int id, string name, string address, double salary, double percent, PayrollDatabase database) 
			: base (id, name, address, database)
		{
			this.salary = salary;
			this.percent = percent;
		}

		protected override PaymentClassification MakeClassification ()
		{
			return new CommissionClassification(salary, percent);
		}

		protected override PaymentSchedule MakeSchedule ()
		{
			return new BiweeklySchedule();
		}
	}

}

