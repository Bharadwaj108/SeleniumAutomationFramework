using AutomationFramework.Base;
using BrowserTests.Pages;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace BrowserTests.Steps
{
    [Binding]
    public class HomeSteps :BaseStep
    {
        [Given(@"I navigate to the Officeworks website")]
        public void GivenINavigateToTheOfficeworksWebsite()
        {
            NaviateSite();
            CurrentPage = GetInstance<HomePage>();
            Assert.IsNotNull(CurrentPage);
        }

    }
}
