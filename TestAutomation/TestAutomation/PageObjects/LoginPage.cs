using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using TestAutomation.Helpers.Driver;

namespace TestAutomation.PageObjects
{
	public class LoginPage
	{
		private readonly WebDriverFactory _webDriverFactory;
		public LoginPage(WebDriverFactory webDriverFactory)
		{
			_webDriverFactory = webDriverFactory;
			PageFactory.InitElements(webDriverFactory.Driver.Get(), this);
		}

		public void Navigate()
		{
			_webDriverFactory.Driver.Get().Navigate().GoToUrl("https://au.unleashedsoftware.com/v2/Account/LogOn");
		}
	
		[FindsBy(How = How.Id, Using = "username")]
		protected IWebElement UsernameTxtBox { get; set; }

		[FindsBy(How = How.Id, Using = "password")]
		protected IWebElement PasswordTxtBox { get; set; }

		[FindsBy(How = How.Id, Using = "btnLogOn")]
		protected IWebElement LoginBtn { get; set; }


		public HomePage LoginAs(string username, string password)
		{
			UsernameTxtBox.SendKeys(username);
			PasswordTxtBox.SendKeys(password);
			LoginBtn.Click();
			return new HomePage(_webDriverFactory);
		}
	}
}
