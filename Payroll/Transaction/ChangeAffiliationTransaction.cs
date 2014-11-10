﻿using System;

namespace Payroll
{
    abstract class ChangeAffiliationTransaction : ChangeEmployeeTransaction
    {
        public ChangeAffiliationTransaction(int empid) : base (empid)
        {
        }

        protected override void Change(Employee e)
        {
            e.Affiliation = Affiliation;
            RecordMembership(e);
        }

        protected abstract Affiliation Affiliation { get; }
        protected abstract void RecordMembership(Employee e);
    }
}

