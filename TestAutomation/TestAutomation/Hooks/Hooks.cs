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
        /// <summary>
        /// Initialize Web driver
        /// </summary>
        [BeforeScenario]
        public void InitializeWebDriver()
        {
            _webDriverFactory.InitWebDriver("Chrome");
        }

        /// <summary>
        /// Quit Web driver
        /// </summary>
        [AfterScenario]
        public void QuitWebDriver()
        {
            _webDriverFactory.Driver.Quit();
        }
    }
}
