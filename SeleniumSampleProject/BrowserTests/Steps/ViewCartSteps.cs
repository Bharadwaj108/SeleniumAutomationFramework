using AutomationFramework.Base;
using BrowserTests.Pages;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace BrowserTests.Steps
{
    [Binding]
    public class ViewCartSteps:BaseStep
    {
        [When(@"Selected the View cart")]
        public void ClickOnViewCart()
        {
            CurrentPage =  CurrentPage.As<ProductCategoryPage>().ClickOnViewCart();
            Assert.IsNotNull(CurrentPage);
        }

        [Then(@"The items ""(.*)"" should be part of my cart")]
        public void ThenTheItemsShouldBePartOfMyCart(string cartItems)
        {
            Assert.True(CurrentPage.As<ViewCartPage>().CheckCartItems(cartItems));
        }


    }
}
