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

		[SetUp]
		public void SetUp()
		{
			database = new RealPayrollDatabase();

			String myConnectionString = "server=127.0.0.1;uid=root;" +
				"pwd=0903;database=payroll;pooling=true;";
			
			try
			{
				connection = new MySql.Data.MySqlClient.MySqlConnection();
				connection.ConnectionString = myConnectionString;
				connection.Open();
			}
			catch (MySql.Data.MySqlClient.MySqlException ex)
			{
				Console.WriteLine(ex.Number + " " + ex.Message);
			}
		}

		[Test]
		public void AddEmployee()
		{
			Employee e = new Employee(123, "July", "NewYotk");

			database.AddEmployee(123, e);

			MySqlCommand c = new MySqlCommand("select * from Employee", connection);
			MySqlDataAdapter ad = new MySqlDataAdapter(c);


			DataSet ds = new DataSet();
			ad.Fill(ds);
			DataTable dt = ds.Tables["table"];

			Assert.AreEqual(1, dt.Rows.Count);
			DataRow row = dt.Rows[0];
			Assert.AreEqual(123, row["EmpId"]);
			Assert.AreEqual("July", row["Name"]);
			Assert.AreEqual("NewYotk", row["Address"]);

		}

		[TearDown]
		public void Teardown()
		{
			connection.Close();
		}
	}
}

