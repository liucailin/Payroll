using System;

namespace Payroll
{
    class ChangeMailTransaction : ChangeMethodTransaction
    {
		public ChangeMailTransaction(int empid, PayrollDatabase database) : base (empid, database)
        {
        }

        protected override PaymentMethod GetMethod()
        {
            return new MailMethod();
        }
    }
}

