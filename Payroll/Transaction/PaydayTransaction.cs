using System;
using System.Collections;

namespace Payroll
{
    class PaydayTransaction : Transaction
    {
        private DateTime payDate;
        private Hashtable payChecks = new Hashtable();

        public PaydayTransaction(DateTime payDate)
        {
            this.payDate = payDate;
        }

        public void Execute()
        {
            ArrayList employeeIds = PayrollDatabase.GetAllEmployeeIds();

            foreach (int empid in employeeIds)
            {
                Employee e = PayrollDatabase.GetEmployee(empid);
                if (e.IsPayDate(payDate))
                {
                    Paycheck payCheck = new Paycheck(payDate);
                    payChecks[empid] = payCheck;
                    e.Payday(payCheck);
                }

            }
        }

        public Paycheck GetPaycheck(int empid)
        {
            return payChecks[empid] as Paycheck;
        }
    }
}

