using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace TestAutomation.Helpers.Driver
{
	class ChromeWebDriver : BaseWebDriver
	{
		private IWebDriver _webDriver;
		public ChromeWebDriver()
		{
			_webDriver = new ChromeDriver();
			_webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
			_webDriver.Manage().Window.Maximize();
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
