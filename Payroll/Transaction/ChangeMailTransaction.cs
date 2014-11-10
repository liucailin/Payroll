using System;

namespace Payroll
{
    class ChangeMailTransaction : ChangeMethodTransaction
    {
        public ChangeMailTransaction(int empid) : base (empid)
        {
        }

        protected override PaymentMethod GetMethod()
        {
            return new MailMethod();
        }
    }
}

