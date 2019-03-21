using AutomationFramework.Base;
using BrowserTests.Pages;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace BrowserTests.Steps
{
    [Binding]
    public class InventoryItemsSteps :BaseStep
    {
        [Given(@"Clicked to view the ""(.*)""")]
        public void SelectProductCategory(string productCategory)
        {
            CurrentPage = CurrentPage.As<ProductsPage>().SelectProductCategory(productCategory);
            Assert.IsNotNull(CurrentPage);
        }

        [When(@"I add the ""(.*)"" to my shopping cart")]
        public void AddTheItemsToMyShoppingCart(string items)
        {
            Assert.True(CurrentPage.As<ProductCategoryPage>().AddItemsToCart(items));
            
        }


    }
}
