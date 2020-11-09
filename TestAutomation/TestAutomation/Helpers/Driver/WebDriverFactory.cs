using System;

namespace TestAutomation.Helpers.Driver
{
    public class WebDriverFactory
    {
        private BaseWebDriver driver;

        public BaseWebDriver Driver
        {
            get
            {
                if (driver == null)
                    throw new NullReferenceException("The WebDriver browser instance was not initialized. You should first call the method InitBrowser.");
                return driver;
            }
            private set
            {
                driver = value;
            }
        }

        public void InitWebDriver(string browserName)
        {
            switch (browserName)
            {
                case "Firefox":
                    driver = new FirefoxWebDriver();
                    break;

                case "Chrome":
                    driver = new ChromeWebDriver();
                    break;
                default:
                    throw new NotImplementedException("A web driver is not supported");
            }
        }
    }
}