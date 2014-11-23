using System;
using System.Collections;

namespace Payroll
{
    class PaydayTransaction : Transaction
    {
        private DateTime payDate;
        private Hashtable payChecks = new Hashtable();

        public PaydayTransaction(DateTime payDate, PayrollDatabase database) : base (database)
        {
            this.payDate = payDate;
        }

        public override void Execute()
        {
            ArrayList employeeIds = database.GetAllEmployeeIds();

            foreach (int empid in employeeIds)
            {
                Employee e = database.GetEmployee(empid);
                if (e.IsPayDate(payDate))
                {
					DateTime startDate = e.GetPayStartDay(payDate);
                    Paycheck payCheck = new Paycheck(startDate, payDate);
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

