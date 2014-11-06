using System;
using NUnit.Core;
using NUnit.Framework;

namespace Payroll.Test
{
	class AddCommissiondEmployee : AddEmployeeTransaction
	{
		private readonly float percent;
		public AddCommissiondEmployee (int id, string name, string address, float percent) : base (id, name, address)
		{
			this.percent = percent;
		}

		protected override PaymentClassification MakeClassification ()
		{
			return new CommissionClassification(percent);
		}

		protected override PaymentSchedule MakeSchedule ()
		{
			return new BiweeklySchedule();
		}
	}

}

