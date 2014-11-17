using System;
using System.Collections;

namespace Payroll
{
    class UnionAffiliation : Affiliation
    {
        private Hashtable charges = new Hashtable();
        private int memberId;
        private double dues;

        public UnionAffiliation()
        {
        }

        public UnionAffiliation(int memberId, double dues)
        {
            this.memberId = memberId;
            this.dues = dues;
        }

        public ServiceCharge GetServiceCharge(DateTime date)
        {
            return charges[date.Day] as ServiceCharge;
        }

        public void AddServiceCharge(ServiceCharge charge)
        {
            charges.Add(charge.ChargeDate.Day, charge);
        }

        public double Dues
        {
            get
            {
                return dues;
            }
        }

        public int MemberId
        {
            get
            {
                return memberId;
            }
        }

        public override double CalculateDeductions(Paycheck paycheck)
        {
            double totalDues = 0;

			if (DateUtil.IsInPayPeriod(paycheck.PayEndDate, paycheck.PayStartDate, paycheck.PayEndDate))
			{
				int fridays = NumberOfFridaysInPayPeriod(paycheck.PayStartDate, paycheck.PayEndDate);
				totalDues = dues * fridays;
			}

			return totalDues;
        }

		private int NumberOfFridaysInPayPeriod (DateTime payStartDate, DateTime payEndDate)
		{
			int fridays = 0;
			for (DateTime day = payStartDate; day <= payEndDate; day.AddDays(1))
			{
				if (day.DayOfWeek == DayOfWeek.Friday)
					fridays++;
			}
			return fridays;
		}
    }
}

