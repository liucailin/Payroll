using System;

namespace Payroll
{
    abstract class ChangeClassificationTransaction : ChangeEmployeeTransaction
    {
		public ChangeClassificationTransaction(int empid, PayrollDatabase database) : base (empid, database)
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

