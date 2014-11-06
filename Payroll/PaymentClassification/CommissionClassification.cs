using System;
using NUnit.Core;
using NUnit.Framework;

namespace Payroll.Test
{
	class CommissionClassification : PaymentClassification
	{
		public CommissionClassification (float percent)
		{
			Percent = percent;
		}

		public float Percent { get; set; }
	}


}

