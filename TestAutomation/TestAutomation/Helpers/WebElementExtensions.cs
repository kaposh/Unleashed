

using Google.Protobuf.WellKnownTypes;
using OpenQA.Selenium;
using System;

namespace TestAutomation.Helpers
{
	public static class WebElementExtensions
	{
		public static void SetValueByString(this IWebElement webElement, string value)
		{
			var type = webElement.GetAttribute("type");
			switch (type)
			{
				case "text":
				case "textarea":
					webElement.SendKeys(value);
					break;
				// Add other control types here
				default:
					throw new NotSupportedException($"Control type {type} not supported");
			}
					
		}
	}
}
