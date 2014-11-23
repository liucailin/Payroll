using System;

namespace Payroll
{
    class SeriveChargeTransaction : Transaction
    {
        private DateTime chargeDate;
        private double chargeAmount;
        private int chargeMemberId;

        public SeriveChargeTransaction(DateTime chargeDate, double chargeAmount, int chargeMemberId, PayrollDatabase database) : base (database)
        {
            this.chargeDate = chargeDate;
            this.chargeAmount = chargeAmount;
            this.chargeMemberId = chargeMemberId;
        }        

        public override void Execute()
        {
            Employee e = database.GetUnionMember(chargeMemberId);

            if (e != null)
            {
                UnionAffiliation ua = e.Affiliation as UnionAffiliation;
                ua.AddServiceCharge(new ServiceCharge(chargeDate, chargeAmount));
            }
            else
                throw new InvalidOperationException("No such union member: " + chargeMemberId);
        }
    }
}

