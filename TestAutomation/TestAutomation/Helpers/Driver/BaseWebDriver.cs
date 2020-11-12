using OpenQA.Selenium;


namespace TestAutomation.Helpers.Driver
{
    public abstract class BaseWebDriver
    {
        /// <summary>
        /// Get Web Driver. Multiple drivers such as ChromeDriver/FirefoxWebDriver are supported
        /// </summary>
        /// <returns>Web driver</returns>
        public abstract IWebDriver Get();
        /// <summary>
        /// Quit web driver
        /// </summary>
        public abstract void Quit();
    }
}
