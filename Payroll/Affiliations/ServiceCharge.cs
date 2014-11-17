using System;

namespace Payroll
{

	public class ServiceCharge
	{
        private DateTime chargeDate;
        private double chargeAmount;

        public ServiceCharge(DateTime chargeDate, double chargeAmount)
        {
            this.chargeDate = chargeDate;
            this.chargeAmount = chargeAmount;
        }

        public DateTime ChargeDate
        {
            get
            {
                return this.chargeDate;
            }
        }

        public double ChargeAmount
        {
            get
            {
                return this.chargeAmount;
            }
        }
        
	}

}

