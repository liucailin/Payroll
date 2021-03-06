//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.18444
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------
using System;
namespace Payroll
{
	class Employee
	{
        private Affiliation affiliation = new NoAffiliation();

		public Employee (int empid, string name, string address)
		{
			EmpId = empid;
			Name = name;
			Address = address;
		}

        public Affiliation Affiliation
        {
            get
            {               
                return affiliation;
            }
            set
            {
                affiliation = value;
            }
        }

		public PaymentClassification Classification {
			get;
			set;
		}

		public PaymentSchedule Schedule {
			get;
			set;
		}

		public PaymentMethod Method {
			get;
			set;
		}

		public int EmpId { get; set; }

		public string Name { get; set; }

		public string Address { get; set; }

        public bool IsPayDate(DateTime payDate)
        {
            return Schedule.IsPayDate(payDate);
        }

        public void Payday(Paycheck paycheck)
        {
            double grossPay = Classification.CalculatePay(paycheck); 
            double deductions = Affiliation.CalculateDeductions(paycheck); 
            double netPay = grossPay - deductions; 
            paycheck.GrossPay = grossPay; 
            paycheck.Deductions = deductions; 
            paycheck.NetPay = netPay; 
            Method.Pay(paycheck);
        }

		public DateTime GetPayStartDay (DateTime payDate)
		{
			return Schedule.GetPayStartDay(payDate);
		}
	}
}

