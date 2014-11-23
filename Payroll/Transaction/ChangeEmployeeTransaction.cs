using System;

namespace Payroll
{
    abstract class ChangeEmployeeTransaction : Transaction
    {
        private int empid;

        public ChangeEmployeeTransaction(int empid, PayrollDatabase database) : base (database)
        {
            this.empid = empid;
        }

        public override void Execute()
        {
            Employee e = database.GetEmployee(empid);
            if (e != null)
            {
                Change(e);
            }
        }

        protected abstract void Change(Employee e);

    }
}

