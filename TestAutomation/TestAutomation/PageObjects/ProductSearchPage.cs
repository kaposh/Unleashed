using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using TestAutomation.Helpers.Driver;

namespace TestAutomation.PageObjects
{
	public class ProductSearchPage: NavigationBar
	{
		private readonly WebDriverFactory _webDriverFactory;
		public ProductSearchPage(WebDriverFactory webDriverFactory) : base(webDriverFactory)
		{
			_webDriverFactory = webDriverFactory;
			PageFactory.InitElements(webDriverFactory.Driver.Get(), this);
		}

		[FindsBy(How = How.Id, Using = "LocalProductSearch")]
		public IWebElement LocalProductSearchTxtBox { get; set; }

		[FindsBy(How = How.Id, Using = "RunProductLocalSearch")]
		public IWebElement ProductSearchButton { get; set; }

		private IWebElement GetProductsTableCell(int row, int column)
		{
			return _webDriverFactory.Driver.Get().FindElement(By.XPath($"//*[@id='ProductLocalSearch_tccell{row}_{column}']/div/a"));
		}

		public void SelectAProductByCode(string productCode)
		{
			LocalProductSearchTxtBox.SendKeys(productCode);
			ProductSearchButton.Click();
			GetProductsTableCell(0, 0).Click();
		}

	}
}
