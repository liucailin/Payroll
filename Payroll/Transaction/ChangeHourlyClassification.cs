using System;

namespace Payroll
{
    class ChangeHourlyClassification : ChangeClassificationTransaction
    {
        private float hour;

        public ChangeHourlyClassification(int empid, float hour) : base (empid)
        {
            this.hour = hour;
        }

        protected override PaymentClassification GetClassification()
        {
            return new HourlyClassification(hour);
        }

        protected override PaymentSchedule GetSchedule()
        {
            return new WeeklySchedule();
        }
    }
}

