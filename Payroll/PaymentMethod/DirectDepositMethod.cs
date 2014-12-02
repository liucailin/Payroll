using System;

namespace Payroll
{
    class DirectDepositMethod : PaymentMethod
    {
		private string bankname;
		private string account;

		public DirectDepositMethod()
		{
		}

        public DirectDepositMethod(string bankname, string account)
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

		public string Account {
			get {
				return account;
			}
			set {
				account = value;
			}
		}
    }
}

