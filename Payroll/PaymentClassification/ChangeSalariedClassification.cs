using System;

namespace Payroll
{
    class ChangeSalariedClassification : ChangeClassificationTransaction
    {
        private double salary;

		public ChangeSalariedClassification(int empid, double salary, PayrollDatabase database) : base (empid, database)
        {
            this.salary = salary;
        }

        protected override PaymentClassification GetClassification()
        {
            return new SalariedClassification(salary);
        }

        protected override PaymentSchedule GetSchedule()
        {
            return new MonthlySchedule();
        }
    }
}

