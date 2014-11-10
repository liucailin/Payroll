using System;

namespace Payroll
{
    abstract class ChangeEmployeeTransaction : Transaction
    {
        private int empid;

        public ChangeEmployeeTransaction(int empid)
        {
            this.empid = empid;
        }

        public void Execute()
        {
            Employee e = PayrollDatabase.GetEmployee(empid);
            if (e != null)
            {
                Change(e);
            }
        }

        protected abstract void Change(Employee e);

    }
}

