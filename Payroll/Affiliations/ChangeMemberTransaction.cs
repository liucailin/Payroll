using System;

namespace Payroll
{
    class ChangeMemberTransaction : ChangeAffiliationTransaction
    {
        private int memberId;
        private double dues;
        public ChangeMemberTransaction(int empId, int memberId, double dues) : base (empId)
        {
            this.memberId = memberId;
            this.dues = dues;
        }


        protected override Affiliation Affiliation
        {
            get
            {
                return new UnionAffiliation(memberId, dues);
            }
        }

        protected override void RecordMembership(Employee e)
        {

            PayrollDatabase.AddUnionMember(memberId, e);

        }


    }
}

