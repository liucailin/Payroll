using System;

namespace Payroll
{
    class Paycheck
    {
        private double grossPay;
        private double deductions;
        private double netPay;
        private DateTime payDate;

        public Paycheck(DateTime payDate)
        {
            this.payDate = payDate;
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

        public DateTime PayDate
        {
            get
            {
                return payDate;
            }
        }

        public string GetField(string field)
        {
            return "";
        }
    }
}

