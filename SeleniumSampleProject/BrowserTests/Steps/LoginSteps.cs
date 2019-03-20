using AutomationFramework.Base;
using AutomationFramework.Utils;
using TechTalk.SpecFlow;

namespace BrowserTests.Steps
{
    [Binding]
    public class LoginSteps :BaseStep
    {
        [Given(@"I have logged as ""(.*)"" using the login credentials")]
        public void LoginToOfficeWorksAccount(string userName)
        {
            
        }

    }
}
