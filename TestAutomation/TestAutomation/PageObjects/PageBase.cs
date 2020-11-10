using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using TestAutomation.Helpers.Driver;

namespace TestAutomation.PageObjects
{
	public class PageBase
	{
		public IWebElement GetControl(string controlName)
		{
			return (IWebElement)GetType().GetProperty(controlName, typeof(IWebElement)).GetValue(this, null);
		}

	}
}
