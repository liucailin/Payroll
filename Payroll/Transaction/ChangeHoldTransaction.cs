using System;

namespace Payroll
{
    class ChangeHoldTransaction : ChangeMethodTransaction
    {
        public ChangeHoldTransaction(int empid) : base (empid)
        {
        }

        protected override PaymentMethod GetMethod()
        {
            return new HoldMethod();
        }
    }
}

