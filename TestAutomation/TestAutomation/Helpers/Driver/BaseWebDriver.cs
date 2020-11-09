using OpenQA.Selenium;


namespace TestAutomation.Helpers.Driver
{
    public abstract class BaseWebDriver
    {
        public abstract IWebDriver Get();
        public abstract void Quit();
    }
}
