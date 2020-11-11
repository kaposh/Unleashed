using TechTalk.SpecFlow;
using TestAutomation.Helpers;
using TestAutomation.Helpers.Driver;
using TestAutomation.PageObjects;

namespace TestAutomation.StepDefinitions
{
	[Binding]
	public sealed class AddSalesOrderPageSteps
	{
		private WebDriverFactory _webDriverFactory;
		private Pages _pages;

		public AddSalesOrderPageSteps(WebDriverFactory webDriverFactory, Pages pages)
		{
			_webDriverFactory = webDriverFactory;
			_pages = pages;
		}

		[When(@"I select a customer with code '(.+)' on add sales order page")]
		public void ISelectACustomer(string customerCode)
		{
			_pages.AddSalesOrderPage.CustomerSearchBtn.Click();
			_pages.CustomerSearchPage = new CustomerSearchPage(_webDriverFactory);
			_pages.CustomerSearchPage.SelectACustomerByCode(customerCode);
		}

		[When(@"I select a product with code '(.+)' on add sales order page")]
		public void ISelectAProduct(string productCode)
		{
			_pages.AddSalesOrderPage.ProductSearchBtn.Click();
			_pages.ProductSearchPage = new ProductSearchPage(_webDriverFactory);
			_pages.ProductSearchPage.SelectAProductByCode(productCode);
		}
	}
}
