using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using TestAutomation.Helpers.Driver;

namespace TestAutomation.PageObjects
{
	public class ViewProductsPage : NavigationBar
	{
		private readonly WebDriverFactory _webDriverFactory;

		public ViewProductsPage(WebDriverFactory webDriverFactory) : base(webDriverFactory)
		{
			_webDriverFactory = webDriverFactory;
			PageFactory.InitElements(webDriverFactory.Driver.Get(), this);
		}

		/// <summary>
		/// Get cell of product table based on row index and column index
		/// </summary>
		/// <param name="rowIndex"></param>
		/// <param name="columnIndex"></param>
		/// <returns></returns>
		public IWebElement GetProductsTableCell(int rowIndex, int columnIndex)
		{//*[@id="ProductList_tccell0_7"]/a
			return _webDriverFactory.Driver.Get().FindElement(By.XPath($"//*[@id='ProductList_tccell{rowIndex}_{columnIndex}']"));
		}
	}
}
