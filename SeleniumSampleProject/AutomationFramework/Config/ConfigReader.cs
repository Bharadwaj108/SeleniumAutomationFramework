using System;
using System.Configuration;
using System.IO;
using System.Reflection;
using AutomationFramework.Base;
using AutomationFramework.ConfigElement;
using AutomationFramework.Utils.Logger;
using AutomationFramework.Utils.Reporter;

namespace AutomationFramework.Config
{
    public class ConfigReader
    {
        public static string TestResourceLocation()
        {
            return Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        }       
        public static void GetTestEnvironment()
        {
            Settings.TestEnvironment = ConfigurationManager.AppSettings["env"];
        }
        public static void SetWebFrameworkSettings()
        {
            GetTestEnvironment();
            Settings.TestLogTarget = (LogTarget)Enum.Parse(typeof(LogTarget),(WebTestConfiguration.TestSettings.WebTestSettings[Settings.TestEnvironment].LogTarget));
            Settings.TestReportTarget = (ReportTarget)Enum.Parse(typeof(ReportTarget), (WebTestConfiguration.TestSettings.WebTestSettings[Settings.TestEnvironment].ReportTarget));
            Settings.TestLogLocation = WebTestConfiguration.TestSettings.WebTestSettings[Settings.TestEnvironment].TestLogFileLocation;
            Settings.TestLogFilePath = Path.Combine(TestResourceLocation(), Settings.TestLogLocation + @"\" + "Log - " + DateTime.Now.ToString("yyyyMMddHHmmss") + ".log");
            Settings.ExtentReportLocation = WebTestConfiguration.TestSettings.WebTestSettings[Settings.TestEnvironment].ExtentReportLocation;
            Settings.ExtentReportFolderLocation = Path.Combine(TestResourceLocation(), Settings.ExtentReportLocation + @"\ExtentReport_" + DateTime.Now.ToString("yyyyMMddHHmmss") + @"\");
            //Settings.TestDataLocation = Path.Combine(TestResourceLocation(), Settings.TestDataLocation);
            Settings.TestDataLocation = Path.Combine(TestResourceLocation(), "TestData");
            Settings.ProjectName = WebTestConfiguration.TestSettings.WebTestSettings[Settings.TestEnvironment].ProjectName;
            Settings.WebBrowser = (BrowserType)Enum.Parse(typeof(BrowserType), (WebTestConfiguration.TestSettings.WebTestSettings[Settings.TestEnvironment].Browser));
            Settings.AUT = WebTestConfiguration.TestSettings.WebTestSettings[Settings.TestEnvironment].AUT;
        }
    }
}
