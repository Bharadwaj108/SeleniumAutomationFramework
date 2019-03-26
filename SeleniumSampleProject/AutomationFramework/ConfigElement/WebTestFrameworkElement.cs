using System.Configuration;

namespace AutomationFramework.ConfigElement
{
    public class WebTestFrameworkElement : ConfigurationElement
    {
        [ConfigurationProperty("name", IsRequired = true)]
        public string Name => (string)base["name"];

        [ConfigurationProperty("browser", IsRequired = true)]
        public string Browser => (string)base["browser"];

        [ConfigurationProperty("applicationUnderTest", IsRequired = true)]
        public string AUT => (string)base["applicationUnderTest"];
                
        [ConfigurationProperty("logTarget", IsRequired = true)]
        public string LogTarget => (string)base["logTarget"];

        [ConfigurationProperty("reportTarget", IsRequired = true)]
        public string ReportTarget => (string)base["reportTarget"];

        [ConfigurationProperty("testLogFileLocation", IsRequired = true)]
        public string TestLogFileLocation => (string)base["testLogFileLocation"];

        [ConfigurationProperty("extentReportLocation", IsRequired = true)]
        public string ExtentReportLocation => (string)base["extentReportLocation"];

        [ConfigurationProperty("testDataLocation", IsRequired = true)]
        public string TestDataLocation => (string)base["testDataLocation"];

        [ConfigurationProperty("projectName", IsRequired = true)]
        public string ProjectName => (string)base["projectName"];

        [ConfigurationProperty("screenShotLocation", IsRequired = true)]
        public string ScreenShotLocation => (string)base["screenShotLocation"];




    }
}
