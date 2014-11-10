using System;

namespace Payroll
{

	public class ServiceCharge
	{
        private DateTime chargeDate;
        private float chargeAmount;

        public ServiceCharge(DateTime chargeDate, float chargeAmount)
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

        public float ChargeAmount
        {
            get
            {
                return this.chargeAmount;
            }
        }
        
	}

}

