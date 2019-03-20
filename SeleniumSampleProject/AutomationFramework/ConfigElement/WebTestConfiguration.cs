
using System.Configuration;

namespace AutomationFramework.ConfigElement
{
    public class WebTestConfiguration : ConfigurationSection
    {
        private static WebTestConfiguration _apiTestConfig = (WebTestConfiguration)ConfigurationManager.GetSection("WebTestConfiguration");

        public static WebTestConfiguration TestSettings => _apiTestConfig;

        [ConfigurationProperty("testSettings")]
        public WebTestFrameworkElementCollection WebTestSettings => (WebTestFrameworkElementCollection)base["testSettings"];
    }
}
