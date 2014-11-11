using System;
using System.Collections;

namespace Payroll
{
    class UnionAffiliation : Affiliation
    {
        private Hashtable charges = new Hashtable();
        private int memberId;
        private float dues;

        public UnionAffiliation()
        {
        }

        public UnionAffiliation(int memberId, float dues)
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

        public float Dues
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
            return dues;
        }
    }
}

