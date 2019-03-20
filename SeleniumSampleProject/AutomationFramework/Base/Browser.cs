using OpenQA.Selenium;

namespace AutomationFramework.Base
{
    public class Browser
    {
        private readonly IWebDriver _driver;

        public Browser(IWebDriver driver) => _driver = driver;

        private BrowserType type;

        public BrowserType GetType()
        {
            return type;
        }

        public void SetType(BrowserType value) => type = value;

        public void GoToUrl(string url) => DriverContext.Driver.Url = url;
    }

    public enum BrowserType
    {
        InternetExplorer,
        FireFox,
        Chrome
    }
}
