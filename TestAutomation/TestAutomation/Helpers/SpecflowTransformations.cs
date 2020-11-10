using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace TestAutomation.Helpers
{
	[Binding]
	public class SpecflowTransformations
	{
		[StepArgumentTransformation]
		public static Dictionary<string, string> ToDictionary(Table table)
		{
			return table.ToDictionary();
		}
	}
}
