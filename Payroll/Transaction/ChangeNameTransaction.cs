using System;

namespace Payroll
{
    class ChangeNameTransaction : ChangeEmployeeTransaction
    {
        private string newName;

        public ChangeNameTransaction(int empid, string newName, PayrollDatabase database) : base (empid, database)
        {
            this.newName = newName;
        }

        protected override void Change(Employee e)
        {
            e.Name = newName;
        }

    }
}

