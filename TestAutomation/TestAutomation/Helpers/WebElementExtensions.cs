

using Google.Protobuf.WellKnownTypes;
using OpenQA.Selenium;
using System;

namespace TestAutomation.Helpers
{
	public static class WebElementExtensions
	{
		/// <summary>
		/// Set value of element by string. Sometimes it is easier for example when setting up multiple elements from specflow table
		/// </summary>
		/// <param name="webElement"></param>
		/// <param name="value"></param>
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
		/// <summary>
		/// Clear content of element and set text
		/// </summary>
		/// <param name="webElement">Element to be modified</param>
		/// <param name="value">Text to be set</param>
		public static void ClearAndSendKeys(this IWebElement webElement, string value)
		{
			webElement.Clear();
			webElement.SendKeys(value);
		}
	}
}
