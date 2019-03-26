using System;
using AutomationFramework.Utils;
using AutomationFramework.Utils.Logger;
using NUnit.Framework;

namespace BrowserTests.CustomException
{
    public class TestException :Exception
    {
        public TestException(string scenarioName, LogType logType, string info, string additionalInfo = null, string furtherAdditionalInfo = null)
        {
            LogHelper.WriteToLog("Test Scenario Name: " + scenarioName, logType);
            LogHelper.WriteToLog(info, logType);
            if (additionalInfo != null)
            {
                LogHelper.WriteToLog(additionalInfo, logType);
                TestContext.WriteLine(additionalInfo);
            }
            if (furtherAdditionalInfo != null)
            {
                LogHelper.WriteToLog(furtherAdditionalInfo, logType);
                TestContext.WriteLine(furtherAdditionalInfo);
            }
            //Write to Nunit Test Context so that it can be written to Nunit TestReprt.xml
            TestContext.WriteLine(info);
        }

        public TestException(string scenarioName, LogType logType, string info, string screenshotFileName=null)
        {
            LogHelper.WriteToLog("Test Scenario Name: " + scenarioName, logType);
            LogHelper.WriteToLog(info, logType);
            
            if (screenshotFileName != null)
            {
                string screenshotFilePath = BrowserScreenshot.CaptureBrowserScreenshot(screenshotFileName);
                LogHelper.WriteToLog("Screenshot added to loaction : " + screenshotFilePath,logType);
                TestContext.WriteLine("Screenshot added to loaction : " + screenshotFilePath);
            }
            //Write to Nunit Test Context so that it can be written to Nunit TestReprt.xml
            TestContext.WriteLine(info);
        }
    }
}
