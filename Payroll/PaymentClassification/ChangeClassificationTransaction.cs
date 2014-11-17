using System;

namespace Payroll
{
    abstract class ChangeClassificationTransaction : ChangeEmployeeTransaction
    {
        public ChangeClassificationTransaction(int empid) : base (empid)
        {
        }

        protected override void Change(Employee e)
        {
            e.Classification = GetClassification();
            e.Schedule = GetSchedule();
        }

        protected abstract PaymentClassification GetClassification();

        protected abstract PaymentSchedule GetSchedule();

    }
}

