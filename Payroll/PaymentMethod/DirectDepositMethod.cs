using System;

namespace Payroll
{
    class DirectDepositMethod : PaymentMethod
    {
		private string bankname;
		private long account;

		public DirectDepositMethod()
		{
		}

        public DirectDepositMethod(string bankname, long account)
        {
			this.bankname = bankname;
			this.account = account;
        }

		public string Bankname {
			get {
				return bankname;
			}
			set {
				bankname = value;
			}
		}

		public long Account {
			get {
				return account;
			}
			set {
				account = value;
			}
		}
    }
}

