using TechTalk.SpecFlow;
using TestAutomation.Helpers.Driver;

namespace TestAutomation.Hooks
{
    [Binding]
    public class Hooks
	{
        public WebDriverFactory _webDriverFactory;
        public Hooks(WebDriverFactory webDriverFactory) 
        {
            _webDriverFactory = webDriverFactory;
        }

        [BeforeScenario]
        public void RunBeforeScenario()
        {
            _webDriverFactory.InitWebDriver("Chrome");
        }

        [AfterScenario]
        public void RunAfterScenario()
        {
            _webDriverFactory.Driver.Quit();
        }
    }
}
