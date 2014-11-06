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
	class AddHourlyEmployee : AddEmployeeTransaction
	{
		private readonly float hour;

		public AddHourlyEmployee (int id, string name, string address, float hour) : base (id, name, address)
		{
			this.hour = hour;
		}

		protected override PaymentClassification MakeClassification ()
		{
			return new HourlyClassification(hour);
		}

		protected override PaymentSchedule MakeSchedule ()
		{
			return new WeeklySchedule();
		}

		
	}
}

