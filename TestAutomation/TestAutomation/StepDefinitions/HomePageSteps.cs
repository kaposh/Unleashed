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

		[When(@"I click on the Inventory menu item on the main navigation bar")]
		public void IClickOnTheInventoryMenuItem() => _pages.HomePage.InventorysMenuItem.Click();

		[When(@"I click on the Products menu item on the main navigation bar")]
		public void IClickOnTheProductsMenuItem() => _pages.HomePage.ProductsMenuItem.Click();

		[When(@"I click on the Add Product menu item on the main navigation bar")]
		public void IClickOnTheAddproductMenuItem()
		{
			_pages.HomePage.AddProductMenuItem.Click();
			_pages.AddProductPage = new AddProductPage(_webDriverFactory);
		}
	}
}
