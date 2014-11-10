using System;
using System.Collections;

namespace Payroll
{
    class UnionAffiliation
    {
        private Hashtable charges = new Hashtable();

        public UnionAffiliation()
        {
        }

        public ServiceCharge GetServiceCharge(DateTime date)
        {
            return charges[date.Day] as ServiceCharge;
        }

        public void AddServiceCharge(ServiceCharge charge)
        {
            charges.Add(charge.ChargeDate.Day, charge);
        }
    }
}

