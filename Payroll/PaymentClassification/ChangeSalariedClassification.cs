using System;

namespace Payroll
{
    class ChangeSalariedClassification : ChangeClassificationTransaction
    {
        private double salary;

        public ChangeSalariedClassification(int empid, double salary) : base (empid)
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

