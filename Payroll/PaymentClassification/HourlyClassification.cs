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
using System.Collections;
namespace Payroll
{
	class HourlyClassification : PaymentClassification
	{
		private Hashtable timeCards = new Hashtable();

		public HourlyClassification (double hourlyRate)
		{
			HourlyRate = hourlyRate;
		}

		public double HourlyRate
		{
			get; set;
		}

		public void AddTimeCard(TimeCard timeCard)
		{
			timeCards.Add(timeCard.Date.Day, timeCard);
		}

		public TimeCard GetTimeCard(DateTime date)
		{
			if (timeCards.Contains(date.Day))
			{
				return timeCards[date.Day] as TimeCard;
			}
			return null;
		}

        public override double CalculatePay(Paycheck paycheck)
        {
			double totalPay = 0;
            foreach (TimeCard timeCard in timeCards.Values)
			{
				if (DateUtil.IsInPayPeriod(timeCard.Date, paycheck.PayStartDate, paycheck.PayEndDate))
				{
					totalPay += CacuatePayForTimeCard(timeCard);
				}
			}
			return totalPay;
        }


		private double CacuatePayForTimeCard(TimeCard card)
		{
			double overTimeHours = Math.Max(0, card.Hours - 8);
			double normalHours = card.Hours - overTimeHours;

			return HourlyRate * normalHours + HourlyRate * 1.5 * overTimeHours;

		}
	}

}

