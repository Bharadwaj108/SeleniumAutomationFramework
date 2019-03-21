using System.Collections.Generic;
using System.Threading;
using AutomationFramework.Base;
using OpenQA.Selenium;

namespace BrowserTests.Pages
{
    public class ProductCategoryPage :BasePage
    {
        IWebElement productsGridViewContainer = DriverContext.Driver.FindElement(By.XPath("//div[@data-ref = 'tile-grid-container']"));
        IWebElement gridViewControl = DriverContext.Driver.FindElement(By.XPath("//span[@data-ref = 'toggle-grid-button']"));
        IWebElement listViewControl = DriverContext.Driver.FindElement(By.XPath("//span[@data-ref = 'toggle-list-button']"));

        /// <summary>
        /// Selects the way the products are displayed on the page
        /// which is grid or list view
        /// </summary>
        /// <param name="view"></param>
        public void SelectProductsView(string view)
        {
            try
            {
                switch (view.Trim().ToLower())
                {
                    case "grid":
                        gridViewControl.Click();
                        Thread.Sleep(3000);
                        break;
                    case "list":
                        listViewControl.Click();
                        Thread.Sleep(3000);
                        break;
                    default:
                        gridViewControl.Click();
                        Thread.Sleep(3000);
                        break;
                }
            }
            catch (System.Exception)
            {
                //Log Error
                throw;
            }
        }

        public bool AddItemsToCartHelper(string item)
        {
            bool flag = true;
            IWebElement productDiv = null;
            try
            {                 
                IList<IWebElement> itemContainers = productsGridViewContainer.FindElements(By.XPath("//div[contains(@data-ref,'product-tile')]"));
                foreach (var itemContainer in itemContainers)
                {
                    try
                    {
                         productDiv = itemContainer.FindElement(By.XPath("(//div[contains(text(), '" + item + "')] | //*[@value='" + item + "'])"));
                    }
                    catch (NoSuchElementException ex)
                    {
                        //do nothing
                    }
                    if(productDiv != null) //get the Add To Cart button reference and click it
                    {
                        IWebElement addToCartButton = itemContainer.FindElement(By.XPath("//button[contains(@data-ref,'add-to-cart-button')]"));
                        addToCartButton.Click();
                        Thread.Sleep(3000);
                        break;
                    }
                }
                //if the product was not found log an error saying product was missing or not fond in the inventory
                if (productDiv is null)
                {
                    //Log Error
                    return false;
                }
            }

            catch (System.Exception)
            {
                flag = false;
                //Log Error
            }
            return flag;
        }

        public bool AddItemsToCart(string items,string separator="|",string view=null)
        {
            bool flag = true;
            try
            {
                //Set the Products view
                if (view is null)
                {
                    view = "grid";
                }                
                SelectProductsView(view);

                //Add items to shopping cart
                List<string> products = new List<string>(items.Split('|'));
                foreach (var item in products)
                {
                    if(!AddItemsToCartHelper(item))
                    {
                        flag = false;
                    }
                }
            }
            catch (System.Exception)
            {
                flag = false;
                //Log Error
            }
            return flag;
        }

    }
}
