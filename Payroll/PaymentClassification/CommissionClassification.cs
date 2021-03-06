using System;
using System.Collections;
namespace Payroll
{
	class CommissionClassification : PaymentClassification
	{
		private Hashtable salesReceipts = new Hashtable();

		public CommissionClassification (double salary, double percent)
		{
			Percent = percent;
			Salary = salary;
		}

		public void AddSalesReceipt (SalesReceipt salesReceipt)
		{
			if (!salesReceipts.ContainsKey(salesReceipt.SaleDate.Day))
			{
				salesReceipts.Add(salesReceipt.SaleDate.Day, salesReceipt);
			}
		}

		public SalesReceipt GetSalesReceipt(DateTime date)
		{
			if (salesReceipts.ContainsKey(date.Day))
			{
				return salesReceipts[date.Day] as SalesReceipt;
			}
			return null;
		}

		public double Percent { get; set; }
		public double Salary { get; set;}

        public override double CalculatePay(Paycheck paycheck)
        {
			double totalPay = Salary;
            foreach (SalesReceipt sr in salesReceipts.Values)
			{
				if (DateUtil.IsInPayPeriod(sr.SaleDate, paycheck.PayStartDate, paycheck.PayEndDate))
				{
					totalPay += CalculatePayInSaleReceipt(sr);
				}
			}
			return totalPay;
        }

		private double CalculatePayInSaleReceipt(SalesReceipt sr)
		{
			return sr.SaleAmount * Percent;
		}


	}


}

