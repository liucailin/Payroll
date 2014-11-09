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
	class TimeCardTransaction : Transaction
	{
		private DateTime date;
		private float hours;
		private int empid;

		public TimeCardTransaction (DateTime date, float hours, int empid)
		{
			this.date = date;
			this.hours = hours;
			this.empid = empid;
		}		

		public void Execute ()
		{
			Employee e = PayrollDatabase.GetEmployee(empid);
			if (e != null)
			{
				HourlyClassification hc = e.Classification as HourlyClassification;

				if (hc != null)
					hc.AddTimeCard(new TimeCard(date, hours));
				else
					throw new InvalidOperationException("Tried to add timecard to non-hourly employee");
			}
			else
				throw new InvalidOperationException("no such employee");

		}
	}
}
