using System;

namespace Payroll
{
    class Paycheck
    {
        private double grossPay;
        private double deductions;
        private double netPay;
        private DateTime payEndDate;
        private DateTime payStartDate;

		public Paycheck(DateTime payStartDate, DateTime payEndDate)
        {
			this.payStartDate = payStartDate;
			this.payEndDate = payEndDate;
        }

        public double GrossPay
        {
            get
            {
                return grossPay;
            }
            set
            {
                grossPay = value;
            }
        }

        public double Deductions
        {
            get
            {
                return deductions;
            }
            set
            {
                deductions = value;
            }
        }

        public double NetPay
        {
            get
            {
                return netPay;
            }
            set
            {
                netPay = value;
            }
        }

		public DateTime PayStartDate
		{
			get
			{
				return payStartDate;
			}
		}

        public DateTime PayEndDate
        {
            get
            {
                return payEndDate;
            }
        }

        public string GetField(string field)
        {
            return "";
        }
    }
}

