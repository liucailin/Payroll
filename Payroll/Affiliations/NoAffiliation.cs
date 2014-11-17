using System;

namespace Payroll
{
    class NoAffiliation : Affiliation
    {
        public NoAffiliation()
        {
        }

        public override double CalculateDeductions(Paycheck paycheck)
        {
            return 0;
        }
    }
}

