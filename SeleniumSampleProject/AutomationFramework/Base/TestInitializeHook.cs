using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;
using AutomationFramework.Config;
using AutomationFramework.Utils.Logger;

namespace AutomationFramework.Base
{
    public class TestInitializeHook :Steps
    {       
        public static void InitializeWebSettings()
        {
            //Set all the settings for framework
            ConfigReader.SetWebFrameworkSettings();

            //Open Browser
            OpenBrowser(Settings.WebBrowser);

        }

        private static void OpenBrowser(BrowserType browserType = BrowserType.Chrome)
        {
            switch (browserType)
            {
                case BrowserType.InternetExplorer:                   
                    break;
                case BrowserType.FireFox:                    
                    break;
                case BrowserType.Chrome:
                    //System.Environment.SetEnvironmentVariable("webdriver.chrome.driver", "");
                    ChromeOptions options = new ChromeOptions();
                    options.AddArgument("start-maximized");
                    DriverContext.Driver = new ChromeDriver(options);
                    DriverContext.Browser = new Browser(DriverContext.Driver);
                    break;
            }

        }

        public virtual void NaviateSite()
        {
            DriverContext.Browser.GoToUrl(Settings.AUT);
            LogHelper.WriteToLog("Opened the browser !!!");
        }
    }
}
