using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using TestAutomation.Helpers.Driver;

namespace TestAutomation.PageObjects
{
	public class AddProductPage :NavigationBar
	{
		private readonly IWebDriver _driver;

		public AddProductPage(WebDriverFactory webDriverFactory) : base(webDriverFactory)
		{
			_driver = webDriverFactory.Driver.Get();
			PageFactory.InitElements(_driver, this);
		}

		[FindsBy(How = How.Id, Using = "Product_ProductCode")]
		public IWebElement ProductCodeTxtBox { get; set; }

		[FindsBy(How = How.Id, Using = "Product_ProductDescription")]
		public IWebElement ProductDescriptionTxtBox { get; set; }

		[FindsBy(How = How.Id, Using = "Product_Barcode")]
		public IWebElement ProductBarCodeTxtBox { get; set; }

		[FindsBy(How = How.Id, Using = "btnSave")]
		public IWebElement ProductSaveBtn { get; set; }

	}
}
