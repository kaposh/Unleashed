using TechTalk.SpecFlow;
using TestAutomation.DataObjects;
using TestAutomation.Helpers;
using TestAutomation.Helpers.Driver;
using TestAutomation.PageObjects;

namespace TestAutomation.StepDefinitions
{
	[Binding]
	public sealed class LoginPageSteps
	{
        private WebDriverFactory _webDriverFactory;
        private Pages _pages;
		public LoginPageSteps(WebDriverFactory webDriverFactory, Pages pages)
		{
			_webDriverFactory = webDriverFactory;
            _pages = pages;

        }
		[Given(@"I navigate to the login page")]
        public void GivenINavigateToTheLoginPage()
        {
            _pages.LoginPage = new LoginPage(_webDriverFactory);
            _pages.LoginPage.Navigate();
        }

        [When(@"I login with as user '(.+)' on the Login Page")]
        public void WhenILoginAsUserOnTheLoginPage(string username)
        {
            LoginPage loginPage = new LoginPage(_webDriverFactory);
            var users = new Users();
            var user = users.GetUser(username);
            _pages.HomePage = loginPage.LoginAs(user.UserName, user.Password);
        }

        [When(@"I login with with username '(.+)' and password '(.+)' on the Login Page")]
        public void WhenILoginWithUsernameAndPasswordOnTheLoginPage(string username, string password)
        {
            LoginPage loginPage = new LoginPage(_webDriverFactory);
            _pages.HomePage = loginPage.LoginAs(username, password);
        }
    }
}
