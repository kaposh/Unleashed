using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using TestAutomation.Helpers.Driver;

namespace TestAutomation.PageObjects
{
	public class AddSalesOrderPage :NavigationBar
	{
		private readonly IWebDriver _driver;

		public AddSalesOrderPage(WebDriverFactory webDriverFactory) : base(webDriverFactory)
		{
			_driver = webDriverFactory.Driver.Get();
			PageFactory.InitElements(_driver, this);
		}

		[FindsBy(How = How.Id, Using = "SelectedCustomerCode")]
		public IWebElement SelectedCustomerCodeTxtBox { get; set; }

		[FindsBy(How = How.Id, Using = "ProductAddLine")]
		public IWebElement ProductAddLineTxtBox { get; set; }

		[FindsBy(How = How.Id, Using = "ProductSearchButton")]
		public IWebElement ProductSearchBtn { get; set; }

		[FindsBy(How = How.Id, Using = "QtyAddLine")]
		public IWebElement QuantityAddLineTxtBox { get; set; }

		[FindsBy(How = How.Id, Using = "PriceAddLine")]
		public IWebElement PriceAddLineTxtBox { get; set; }

		[FindsBy(How = How.Id, Using = "btnAddOrderLine")]
		public IWebElement AddOrderLineButton { get; set; }

		[FindsBy(How = How.Id, Using = "CustomerSearchButton")]
		public IWebElement CustomerSearchBtn { get; set; }

		[FindsBy(How = How.Id, Using = "btnComplete")]
		public IWebElement CompleteOrderBtn { get; set; }

		[FindsBy(How = How.Id, Using = "btnAddOrderLine")]
		public IWebElement AddOrderLineBtn { get; set; }

	}
}
