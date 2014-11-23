using System;
using System.Collections;

namespace Payroll
{
	interface PayrollDatabase
	{
		void AddEmployee (int id, Employee employee);

		Employee GetEmployee (int id);

		ArrayList GetAllEmployeeIds ();

		void DeleteEmployee (int id);

		void AddUnionMember (int id, Employee employee);
       
		Employee GetUnionMember (int id);

		void RemoveUnionMember (int memberId);
       
	}
}

