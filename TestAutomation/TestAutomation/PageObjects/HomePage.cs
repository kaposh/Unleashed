using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using TestAutomation.Helpers.Driver;

namespace TestAutomation.PageObjects
{
	public class HomePage :NavigationBar
	{
		private readonly IWebDriver _driver;

		public HomePage(WebDriverFactory webDriverFactory) : base(webDriverFactory)
		{
			_driver = webDriverFactory.Driver.Get();
			PageFactory.InitElements(_driver, this);
		}

		// Add other locators of main page here
	}
}
