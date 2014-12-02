using System;
using Payroll;
using NUnit.Framework;
using MySql.Data.MySqlClient;
using System.Data;

namespace Payroll.Test
{
	[TestFixture]
	public class RealPayrollDatabaseTest
	{
		PayrollDatabase database;
		MySqlConnection connection;
		Employee employee;

		[SetUp]
		public void SetUp()
		{
			database = new MySqlPayrollDatabase();

			string myConnectionString = "server=104.224.133.206;uid=liucailin;" +
				"pwd=0903;database=Payroll;pooling=true;";
			/*String myConnectionString = "server=127.0.0.1;uid=root;" +
				"pwd=0903;database=payroll;pooling=true;";*/
			
			try
			{
				connection = new MySql.Data.MySqlClient.MySqlConnection();
				connection.ConnectionString = myConnectionString;
				connection.Open();
				new MySqlCommand ("delete from Employee", connection).ExecuteNonQuery();
			}
			catch (MySql.Data.MySqlClient.MySqlException ex)
			{
				Console.WriteLine(ex.Number + " " + ex.Message);
			}
			AddJuly();
		}

		void AddJuly ()
		{
			employee = new Employee (123, "July", "NewYotk");
			employee.Schedule = new MonthlySchedule();
			employee.Classification = new SalariedClassification(1000);
			employee.Method = new DirectDepositMethod();
		}

		DataTable GetEmployeeTable ()
		{
			MySqlCommand c = new MySqlCommand ("select * from Employee", connection);
			MySqlDataAdapter ad = new MySqlDataAdapter (c);
			DataSet ds = new DataSet ();
			ad.Fill (ds);
			DataTable table = ds.Tables ["table"];
			return table;
		}

		[Test]
		public void AddEmployee()
		{
			database.AddEmployee(123, employee);
			var table = GetEmployeeTable ();

			Assert.AreEqual(1, table.Rows.Count);
			DataRow row = table.Rows[0];
			Assert.AreEqual(123, row["EmpId"]);
			Assert.AreEqual("July", row["Name"]);
			Assert.AreEqual("NewYotk", row["Address"]);
		}

		[Test]
		public void ScheduleGetsSaved()
		{
			database.AddEmployee(123, employee);
			var table = GetEmployeeTable();

			Assert.AreEqual(1, table.Rows.Count);
			DataRow row = table.Rows[0];
			Assert.AreEqual("monthly", row["ScheduleType"]);
		}

		[Test]
		public void MethodsGetsSaved()
		{

		}

		private void CheckSavedPaymentMethod(PaymentMethod method, string expectedCode)
		{
			if (method is DirectDepositMethod)
			{

			}

		}

		[TearDown]
		public void Teardown()
		{
			connection.Close();
		}
	}
}

