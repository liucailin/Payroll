using System;

namespace Payroll
{
    class ChangeHoldTransaction : ChangeMethodTransaction
    {
		public ChangeHoldTransaction(int empid, PayrollDatabase database) : base (empid, database)
        {
        }

        protected override PaymentMethod GetMethod()
        {
            return new HoldMethod();
        }
    }
}

