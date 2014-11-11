using System;

namespace Payroll
{
    class ChangeHourlyClassification : ChangeClassificationTransaction
    {
        private double hour;

        public ChangeHourlyClassification(int empid, double hour) : base (empid)
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

