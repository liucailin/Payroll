// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      Mono Runtime Version: 4.0.30319.1
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------
using System;
namespace Payroll
{
	public class PayrollApplication
	{
		static void Main(string[] args)
		{
			TransactionSource ts = new TextParserTransactonSource();
			while (true)
			{
				Transaction t = ts.GetTransaction();
				if (t != null)
					t.Execute();
				else
					break;
			}
		}
	}
}

