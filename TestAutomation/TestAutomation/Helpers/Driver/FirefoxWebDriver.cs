using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace TestAutomation.Helpers.Driver
{
	class FirefoxWebDriver : BaseWebDriver
	{
		private IWebDriver _webDriver;
		public FirefoxWebDriver()
		{
			_webDriver = new FirefoxDriver();
		}
		public override void Quit()
		{
			_webDriver.Quit();
		}
		public override IWebDriver Get()
		{
			return _webDriver;
		}
	}
}
