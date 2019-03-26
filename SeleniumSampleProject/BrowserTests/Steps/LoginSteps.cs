using AutomationFramework.Base;
using AutomationFramework.Utils;
using BrowserTests.Pages;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace BrowserTests.Steps
{
    [Binding]
    public class LoginSteps :BaseStep
    {
        [Given(@"I have logged as ""(.*)"" using the login credentials")]
        public void LoginToOfficeWorksAccount(string userName)
        {
            CurrentPage = CurrentPage.As<LoginPage>().Login(userName);
            Assert.IsNotNull(CurrentPage);
        }        

    }
}
