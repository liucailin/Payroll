using System;

namespace Payroll
{
    class ChangeDirectTransaction : ChangeMethodTransaction
    {
		public ChangeDirectTransaction(int empid, PayrollDatabase database) : base (empid, database)
        {
        }

        protected override PaymentMethod GetMethod()
        {
            return new DirectDepositMethod();
        }
    }
}

