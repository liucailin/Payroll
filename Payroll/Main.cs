using System;

namespace Payroll
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Console.WriteLine ("Hello World!");

			DateTime d = DateTime.Now;
			Console.WriteLine(d);
			Console.WriteLine(d.Kind);
			Console.WriteLine(DateTime.UtcNow);

		}
	}
}
