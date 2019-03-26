using System;
using System.IO;
using OpenQA.Selenium;
using AutomationFramework.Config;
using AutomationFramework.Base;

namespace AutomationFramework.Utils
{
    public class BrowserScreenshot
    {
        public static string CaptureBrowserScreenshot(string fileName)
        {
            string filePath = Path.Combine(Settings.ScreenShotPath, fileName + DateTime.Now.ToString("yyyyddMHHmmss")+".png");
            Screenshot testScreenshot = ((ITakesScreenshot)DriverContext.Driver).GetScreenshot();
            testScreenshot.SaveAsFile(filePath);
            return filePath;
        }
    }
}
