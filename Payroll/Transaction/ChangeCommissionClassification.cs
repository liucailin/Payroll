using System;

namespace Payroll
{
    class ChangeCommissionClassification : ChangeClassificationTransaction
    {
        private float percent;

        public ChangeCommissionClassification(int empid, float percent) : base (empid)
        {
            this.percent = percent;
        }

        protected override PaymentClassification GetClassification()
        {
            return new CommissionClassification(percent);
        }

        protected override PaymentSchedule GetSchedule()
        {
            return new BiweeklySchedule();
        }
    }
}

