using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace TestAutomation.Helpers
{
	public static class SpecflowExtensions
	{
		public static Dictionary<string, string> ToDictionary(this Table specflowTable)
		{
			return specflowTable.Rows.Where(row => !string.IsNullOrWhiteSpace(row[0]))
				.ToDictionary(row => row[0], row => row[1]);
		}
	}
}
