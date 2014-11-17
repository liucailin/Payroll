using System;

namespace Payroll
{
    class ChangeDirectTransaction : ChangeMethodTransaction
    {
        public ChangeDirectTransaction(int empid) : base (empid)
        {
        }

        protected override PaymentMethod GetMethod()
        {
            return new DirectMethod();
        }
    }
}

