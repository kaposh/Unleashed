using NUnit.Framework;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using TestAutomation.Helpers;
using TestAutomation.Helpers.Driver;

namespace TestAutomation.StepDefinitions
{
	[Binding]
	public sealed class AddProductPageSteps
	{
		private WebDriverFactory _webDriverFactory;
		private Pages _pages;

		public AddProductPageSteps(WebDriverFactory webDriverFactory, Pages pages)
		{
			_webDriverFactory = webDriverFactory;
			_pages = pages;
		}

		[When(@"I add a new product with following properties:")]
		public void IAddNewProduct(Dictionary<string, string> productProperties)
		{
			foreach(var property in productProperties)
			{
				var control = _pages.AddProductPage.GetControl(property.Key);
				control.SetValueByString(property.Value);
			}
			_pages.AddProductPage.ProductSaveBtn.Click();
		}
	}
}
