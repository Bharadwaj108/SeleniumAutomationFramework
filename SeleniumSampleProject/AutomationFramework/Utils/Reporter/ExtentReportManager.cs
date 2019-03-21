using System.IO;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using TechTalk.SpecFlow;

namespace AutomationFramework.Utils.Reporter
{
    public class ExtentReportManager
    {
        public ExtentHtmlReporter ExtentHtmlReporter { get; set; } = null;
        public ExtentReports ExtentReport { get; set; }
        public ExtentTest TestFeature { get; set; }
        public ExtentTest TestScenario { get; set; }
        public ExtentReportManager(string logFileLocation)
        {
            ConfigureExtentReport(logFileLocation);
        }        
        public void ConfigureExtentReport(string reportfolderLocation)
        {
            if (!Directory.Exists(reportfolderLocation))
            {
                Directory.CreateDirectory(reportfolderLocation);
            }
            ExtentHtmlReporter = new ExtentHtmlReporter(reportfolderLocation);                 
            ExtentHtmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Dark;
            ExtentHtmlReporter.Config.DocumentTitle = "Test Automation Report";
            ExtentHtmlReporter.Config.ReportName = "Test Automation Report";            
            ExtentReport = new ExtentReports();            
            ExtentReport.AttachReporter(ExtentHtmlReporter);
            

        }

        public void AssignCategory(ScenarioContext scenariocontext, ExtentTest testScenario)
        {
            string[] tags = scenariocontext.ScenarioInfo.Tags;
            for (int i = 0; i < tags.Length; i++)
            {
                switch (tags[i].Trim().ToUpper())
                {
                    case "WPN":
                        testScenario = testScenario.AssignCategory("Withdrawal Of Priority Notice");
                        break;
                    case "PNN":
                        testScenario = testScenario.AssignCategory("Priority Notice New");
                        break;
                    case "EPN":
                        testScenario = testScenario.AssignCategory("Priority Notice Extension");
                        break;
                    case "CAV":
                        testScenario = testScenario.AssignCategory("Caveat");
                        break;
                    case "WCAV":
                        testScenario = testScenario.AssignCategory("Withdraw Caveat");
                        break;
                    default:
                        testScenario = testScenario.AssignCategory("All Tests");
                        break;
                }

            }
        }
    }
}
