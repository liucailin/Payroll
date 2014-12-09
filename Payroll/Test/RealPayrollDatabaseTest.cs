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
				ClearDatabase();
			}
			catch (MySql.Data.MySqlClient.MySqlException ex)
			{
				Console.WriteLine(ex.Number + " " + ex.Message);
			}
			AddJuly();
		}

		void ClearDatabase()
		{
			new MySqlCommand ("delete from Employee", connection).ExecuteNonQuery();
			new MySqlCommand ("delete from DirectDepositAccount", connection).ExecuteNonQuery();
		}

		void AddJuly ()
		{
			employee = new Employee (123, "July", "NewYotk");
			employee.Schedule = new MonthlySchedule();
			employee.Classification = new SalariedClassification(1000);
			employee.Method = new DirectDepositMethod();
		}

		DataTable LoadTable (string tableName)
		{
			MySqlCommand c = new MySqlCommand (string.Format("select * from {0}", tableName), connection);
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
			var table = LoadTable ("Employee");

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
			var table = LoadTable("Employee");

			Assert.AreEqual(1, table.Rows.Count);
			DataRow row = table.Rows[0];
			Assert.AreEqual("monthly", row["ScheduleType"]);
		}

		private void CheckSavedSchedule(PaymentSchedule schedule, string expectedCode)
		{
			employee.Schedule = schedule;
			database.AddEmployee(123, employee);
			
			DataTable table = LoadTable("Employee");
			DataRow row = table.Rows[0];

			Assert.AreEqual(expectedCode, row["ScheduleType"]);
		}

		[Test]
		public void MethodsGetsSaved()
		{
			CheckSavedPaymentMethod(new HoldMethod(), "hold");
			ClearDatabase();
			CheckSavedPaymentMethod(new DirectDepositMethod("Bank -1", 01234), "directdeposite");
			ClearDatabase();
			CheckSavedPaymentMethod(new MailMethod(), "mail");	
			ClearDatabase();
		}

		[Test]
		public void DirectDepositeMethodGetSaved()
		{
			CheckSavedPaymentMethod(new DirectDepositMethod("Bank -1", 101234), "directdeposite");

			var table = LoadTable("DirectDepositAccount");
			Assert.AreEqual(1, table.Rows.Count);
			var row = table.Rows[0];
			Assert.AreEqual("Bank -1", row["Bank"]);
			Assert.AreEqual(101234, row["Account"]);
			Assert.AreEqual(123, row["EmpId"]);
		}

		private void CheckSavedPaymentMethod(PaymentMethod method, string expectedCode)
		{
			employee.Method = method;
			database.AddEmployee(123, employee);

			DataTable table = LoadTable("Employee");
			Assert.AreEqual(1, table.Rows.Count);
			DataRow row = table.Rows[0];

			Assert.AreEqual(expectedCode, row["PaymentMethodType"]);
		}

		[TearDown]
		public void Teardown()
		{
			connection.Close();
		}
	}
}

