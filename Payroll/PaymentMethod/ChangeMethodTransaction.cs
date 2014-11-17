using System;

namespace Payroll
{
    abstract class ChangeMethodTransaction : ChangeEmployeeTransaction
    {
        public ChangeMethodTransaction(int empid) : base (empid)
        {
        }

        protected override void Change(Employee e)
        {
            e.Method = GetMethod();
        }

        protected abstract PaymentMethod GetMethod();

    }
}

