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
using MySql.Data.MySqlClient;
namespace Payroll
{
	class RealPayrollDatabase : PayrollDatabase
	{
		private MySqlConnection connection;

		public RealPayrollDatabase()
		{
			string connectionString = 
				"Server=localhost;" +
				"Database=Payroll;" +
				"User ID=sa;" +
				"Password=sa;" +
				"Pooling=false";

			connection = new MySqlConnection(connectionString);
			connection.Open();
		}

		public void AddEmployee (int id, Employee employee)
		{
			string addCommand = "";
			MySqlCommand command = new MySqlCommand("", connection);

		}

		public Employee GetEmployee (int id)
		{
			throw new NotImplementedException ();
		}

		public System.Collections.ArrayList GetAllEmployeeIds ()
		{
			throw new NotImplementedException ();
		}

		public void DeleteEmployee (int id)
		{
			throw new NotImplementedException ();
		}

		public void AddUnionMember (int id, Employee employee)
		{
			throw new NotImplementedException ();
		}

		public Employee GetUnionMember (int id)
		{
			throw new NotImplementedException ();
		}

		public void RemoveUnionMember (int memberId)
		{
			throw new NotImplementedException ();
		}
	}
}

