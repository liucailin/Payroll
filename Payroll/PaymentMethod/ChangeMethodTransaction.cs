using System;

namespace Payroll
{
    abstract class ChangeMethodTransaction : ChangeEmployeeTransaction
    {
		public ChangeMethodTransaction(int empid, PayrollDatabase database) : base (empid, database)
        {
        }

        protected override void Change(Employee e)
        {
            e.Method = GetMethod();
        }

        protected abstract PaymentMethod GetMethod();

    }
}

