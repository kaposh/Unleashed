using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using TestAutomation.Helpers.Driver;

namespace TestAutomation.PageObjects
{
	public class NavigationBar : PageBase
	{
		private readonly IWebDriver _driver;

		public NavigationBar(WebDriverFactory webDriverFactory)
		{
			_driver = webDriverFactory.Driver.Get();
			PageFactory.InitElements(_driver, this);
		}

		#region Top level menu elements  
		[FindsBy(How = How.Id, Using = "menubar-0")]
		public IWebElement ManageYourTrialMenuItem { get; set; }

		[FindsBy(How = How.Id, Using = "menubar-1")]
		public IWebElement PurchasesMenuItem { get; set; }

		[FindsBy(How = How.Id, Using = "menubar-2")]
		public IWebElement InventorysMenuItem { get; set; }
		#endregion

		#region Inventory menu subitems 
		[FindsBy(How = How.LinkText, Using = "Transactions")]
		public IWebElement TransactionsMenuItem { get; set; }

		[FindsBy(How = How.LinkText, Using = "Products")]
		public IWebElement ProductsMenuItem { get; set; }
		#endregion

		#region Products menu subitems
		[FindsBy(How = How.LinkText, Using = "Add Product")]
		public IWebElement AddProductMenuItem { get; set; }
		#endregion
	}
}
