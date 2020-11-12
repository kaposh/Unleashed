using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace TestAutomation.Helpers
{
	[Binding]
	public class SpecflowTransformations
	{
		/// <summary>
		/// Transformation of table to dictionary which is done every time a step has Dictionary<string, string> parameter
		/// </summary>
		/// <param name="table"></param>
		/// <returns></returns>
		[StepArgumentTransformation]
		public static Dictionary<string, string> ToDictionary(Table table) => table.ToDictionary();
	}
}
