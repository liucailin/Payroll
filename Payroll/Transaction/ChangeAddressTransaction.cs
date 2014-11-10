using System;

namespace Payroll
{
    class ChangeAddressTransaction : ChangeEmployeeTransaction
    {
        private string newAddress;

        public ChangeAddressTransaction(int empid, string newAddress) : base (empid)
        {
            this.newAddress = newAddress;
        }

        protected override void Change(Employee e)
        {
            e.Address = newAddress;
        }


    }
}

