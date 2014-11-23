//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.18444
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Collections;


namespace Payroll
{
	class InMemoryPayrollDataBase : PayrollDatabase
	{
		private static Hashtable employees = new Hashtable();
		private static Hashtable unionMembers = new Hashtable();
		private static ArrayList employeeIds = new ArrayList();
		
		public void AddEmployee(int id, Employee employee)
		{
			if (!employees.ContainsKey(id))
			{
				employees.Add(id, employee);
				employeeIds.Add(id);
			}
		}
		
		public Employee GetEmployee(int id)
		{
			if (employees.ContainsKey(id))
			{
				return employees[id] as Employee;
			}
			return null;
		}
		
		public ArrayList GetAllEmployeeIds()
		{
			return employeeIds;
		}
		
		public void DeleteEmployee(int id)
		{
			if (employees.ContainsKey(id))
			{
				employees.Remove(id);
				employeeIds.Remove(id);
			}
		}
		
		public void AddUnionMember(int id, Employee employee)
		{
			unionMembers.Add(id, employee);
		}
		
		public Employee GetUnionMember(int id)
		{
			if (unionMembers.ContainsKey(id))
			{
				return unionMembers[id] as Employee;
			}
			return null;
		}
		
		public void RemoveUnionMember(int memberId)
		{
			if (unionMembers.ContainsKey(memberId))
			{
				unionMembers.Remove(memberId);
			}
		}
	}
}

