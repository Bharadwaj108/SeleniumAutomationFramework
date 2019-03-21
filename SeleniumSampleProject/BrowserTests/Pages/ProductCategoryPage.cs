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
            IWebElement container = null;
            try
            {                 
                IList<IWebElement> itemContainers = productsGridViewContainer.FindElements(By.XPath("//div[contains(@data-ref,'product-tile')]"));
                IWebElement addToCartButton = null;
                /*foreach (var itemContainer in itemContainers)
                {
                    try
                    {
                        productDiv = itemContainer.FindElement(By.XPath("(//div[contains(text(), '" + item + "')] | //*[@value='" + item + "'])"));
                        container = itemContainer;
                        break;
                        //productDiv = itemContainer.FindElement(By.XPath("(//div[contains(text(),'" + item + "')]"));
                    }
                    catch (NoSuchElementException ex)
                    {
                        //do nothing
                    }                    
                }*/
                for (int i = 0; i < itemContainers.Count; i++)
                {
                    try
                    {
                        //productDiv = itemContainers[i].FindElement(By.XPath("(//a[(text()='" + item + "')]"));
                        IList<IWebElement> anchors = itemContainers[i].FindElements(By.TagName("a"));
                        foreach (var anchor in anchors)
                        {
                            string anchorText = anchor.Text;
                            if (string.Compare(anchorText,item,true) == 0)
                            {
                                addToCartButton = itemContainers[i].FindElement(By.XPath("//button[contains(@data-ref,'add-to-cart-button')]"));
                                addToCartButton.Click();
                                container = itemContainers[i];
                                return true;
                            }
                        }                        
                        //productDiv = itemContainer.FindElement(By.XPath("(//div[contains(text(),'" + item + "')]"));
                    }
                    catch (NoSuchElementException ex)
                    {
                        //do nothing
                    }
                }                
                //if the product was not found log an error saying product was missing or not fond in the inventory
                if (container is null)
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

        public ViewCartPage ClickOnViewCart()
        {
            try
            {
                DriverContext.Driver.FindElement(By.XPath("//div[@data-ref='navLink-cart']")).Click();
                Thread.Sleep(2000);
                DriverContext.Driver.FindElement(By.XPath("//button[text()='View Cart & Checkout']")).Click();
                Thread.Sleep(5000);
            }
            catch (System.Exception)
            {

                return null;
            }
            return GetInstance<ViewCartPage>();
        }
    }
}
