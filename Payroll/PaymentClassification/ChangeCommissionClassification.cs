using System;

namespace Payroll
{
    class ChangeCommissionClassification : ChangeClassificationTransaction
    {
        private double percent;
        private double salary;

		public ChangeCommissionClassification(int empid, double salary, double percent, PayrollDatabase database) : base (empid, database)
        {
            this.percent = percent;
			this.salary = salary;
        }

        protected override PaymentClassification GetClassification()
        {
			return new CommissionClassification(salary, percent);
        }

        protected override PaymentSchedule GetSchedule()
        {
            return new BiweeklySchedule();
        }
    }
}

