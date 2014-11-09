using System;
using System.Collections;
namespace Payroll
{
	class CommissionClassification : PaymentClassification
	{
		private Hashtable salesReceipts = new Hashtable();

		public CommissionClassification (float percent)
		{
			Percent = percent;
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

		public float Percent { get; set; }
	}


}

