using TechTalk.SpecFlow;
using TestAutomation.Helpers;
using TestAutomation.Helpers.Driver;
using TestAutomation.PageObjects;

namespace TestAutomation.StepDefinitions
{
	[Binding]
	public sealed class HomePageSteps
	{
        private WebDriverFactory _webDriverFactory;
        private Pages _pages;
		public HomePageSteps(WebDriverFactory webDriverFactory, Pages pages)
		{
			_webDriverFactory = webDriverFactory;
            _pages = pages;
        }

		#region Top level
		[When(@"I click on the Inventory menu item on the main navigation bar")]
		public void IClickOnTheInventoryMenuItem() => _pages.HomePage.InventorysMenuItem.Click();

		[When(@"I click on the Sales menu item on the main navigation bar")]
		public void IClickOnTheSalesMenuItem() => _pages.HomePage.SalesMenuItem.Click();
		#endregion

		#region Sales
		[When(@"I click on the Orders menu item on the main navigation bar")]
		public void IClickOnTheOrdersMenuItem() => _pages.HomePage.OrdersMenuItem.Click();
		#endregion

		#region Inventory
		[When(@"I click on the Products menu item on the main navigation bar")]
		public void IClickOnTheProductsMenuItem() => _pages.HomePage.ProductsMenuItem.Click();
		#endregion


		#region Inventory -> Products
		[When(@"I click on the Add Product menu item on the main navigation bar")]
		public void IClickOnTheAddproductMenuItem()
		{
			_pages.HomePage.AddProductMenuItem.Click();
			_pages.AddProductPage = new AddProductPage(_webDriverFactory);
		}
		#endregion

		#region Sales -> Orders
		[When(@"I click on the Add Sales Order menu item on the main navigation bar")]
		public void IClickOnTheAddSalesOrderMenuItem()
		{
			_pages.HomePage.AddSalesOrderMenuItem.Click();
			_pages.AddSalesOrderPage = new AddSalesOrderPage(_webDriverFactory);
		}
		#endregion
	}
}
