using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using TestAutomation.Helpers.Driver;

namespace TestAutomation.PageObjects
{
	public class CustomerSearchPage
	{
		private readonly WebDriverFactory _webDriverFactory;
		public CustomerSearchPage(WebDriverFactory webDriverFactory)
		{
			_webDriverFactory = webDriverFactory;
			PageFactory.InitElements(webDriverFactory.Driver.Get(), this);
		}

		[FindsBy(How = How.Id, Using = "CustomerSearchCode")]
		public IWebElement CustomerSearchCodeTxtBox { get; set; }

		[FindsBy(How = How.Id, Using = "RunCustomerSearch")]
		public IWebElement CustomerSearchButton { get; set; }

		private IWebElement GetCustomersTableCell(int row, int column)
		{
			return _webDriverFactory.Driver.Get().FindElement(By.XPath($"//*[@id='CustomerLocalSearch_tccell{row}_{column}']/a"));
		}

		public void SelectACustomerByCode(string customerCode)
		{
			CustomerSearchCodeTxtBox.SendKeys(customerCode);
			CustomerSearchButton.Click();
			// TODO get control by customer code
			GetCustomersTableCell(0, 0).Click();
		}

	}
}
