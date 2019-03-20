using AutomationFramework.Base;
using AutomationFramework.Config;


namespace AutomationFramework.Utils.Reporter
{
    public class ReportHelper
    {
        public static ExtentReportManager reportManager;
        public static void InitializeTestReport()
        {
            switch (Settings.TestReportTarget)
            {
                case ReportTarget.Klov:
                    break;
                case ReportTarget.Extent:
                    reportManager = new ExtentReportManager(Settings.ExtentReportFolderLocation);
                    break;
                case ReportTarget.Pickles:
                    break;
                case ReportTarget.None:
                    break;
                default:
                    break;
            }
        }

        public static void TestCleanup()
        {
            switch (Settings.TestReportTarget)
            {
                case ReportTarget.Klov:
                    break;
                case ReportTarget.Extent:
                    reportManager.ExtentReport.Flush();
                    break;
                case ReportTarget.Pickles:
                    break;
                case ReportTarget.None:
                    break;
                default:
                    break;
            }
            DriverContext.Driver.Close();
        }
    }
}
