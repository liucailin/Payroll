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
using System.Globalization;


namespace Payroll
{
	class BiweeklySchedule : PaymentSchedule
	{
		public BiweeklySchedule ()
		{
		}

        public override bool IsPayDate(DateTime payDate)
        {
        	return IsBiWeeklyDate(payDate);
        }

        private bool IsBiWeeklyDate(DateTime date)
        {
			GregorianCalendar cal = new System.Globalization.GregorianCalendar();
			int weekNum = cal.GetWeekOfYear(date, CalendarWeekRule.FirstDay, DayOfWeek.Sunday);
			return date.DayOfWeek == DayOfWeek.Friday && (weekNum % 2 == 1);
        }

		public override DateTime GetPayStartDay (DateTime payDate)
		{
			return payDate.AddDays(-14);
		}
	}
}

