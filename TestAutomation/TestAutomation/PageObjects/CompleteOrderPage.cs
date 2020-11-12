using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using TestAutomation.Helpers.Driver;

namespace TestAutomation.PageObjects
{
	public class CompleteOrderPage
	{
		private readonly WebDriverFactory _webDriverFactory;

		public CompleteOrderPage(WebDriverFactory webDriverFactory)
		{
			_webDriverFactory = webDriverFactory;
			PageFactory.InitElements(_webDriverFactory.Driver.Get(), this);
		}

		[FindsBy(How = How.Id, Using = "generic-confirm-modal-yes")]
		private IWebElement YesButton { get; set; }

		[FindsBy(How = How.Id, Using = "generic-confirm-modal-yes")]
		private IWebElement NoButton { get; set; }

		[FindsBy(How = How.Id, Using = "generic-confirm-dialog")]
		private IWebElement ConfirmDialog { get; set; }

		public bool ConfirmDialogIsVisible()
		{
			return ConfirmDialog != null && ConfirmDialog.Displayed;
		}

		public AddSalesOrderPage PressYes()
		{
			YesButton.Click();
			return new AddSalesOrderPage(_webDriverFactory);
		}
		public AddSalesOrderPage PressNo()
		{
			NoButton.Click();
			return new AddSalesOrderPage(_webDriverFactory);
		}
	}
}
