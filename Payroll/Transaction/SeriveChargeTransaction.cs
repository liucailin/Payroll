using System;

namespace Payroll
{
    class SeriveChargeTransaction : Transaction
    {
        private DateTime chargeDate;
        private float chargeAmount;
        private int chargeMemberId;

        public SeriveChargeTransaction(DateTime chargeDate, float chargeAmount, int chargeMemberId)
        {
            this.chargeDate = chargeDate;
            this.chargeAmount = chargeAmount;
            this.chargeMemberId = chargeMemberId;
        }        

        public void Execute()
        {
            Employee e = PayrollDatabase.GetUnionMember(chargeMemberId);

            if (e != null)
            {
                UnionAffiliation ua = e.Affiliation;
                ua.AddServiceCharge(new ServiceCharge(chargeDate, chargeAmount));
            }
            else
                throw new InvalidOperationException("No such union member: " + chargeMemberId);
        }
    }
}

