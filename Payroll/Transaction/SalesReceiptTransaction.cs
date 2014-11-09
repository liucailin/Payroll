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
	class SalesReceiptTransaction : Transaction
	{
		private DateTime saleDate;
		private float saleAmount;
		private int empid;

		public SalesReceiptTransaction (DateTime saleDate, float saleAmount, int empid)
		{
			this.saleDate = saleDate;
			this.saleAmount = saleAmount;
			this.empid = empid;
		}		

		public void Execute ()
		{
			Employee e = PayrollDatabase.GetEmployee(empid);

			if (e != null)
			{
				CommissionClassification cc = e.Classification as CommissionClassification;

				if (cc != null)
				{
					cc.AddSalesReceipt(new SalesReceipt(saleDate, saleAmount));
				}
			}
		}
	}
}
