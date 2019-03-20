using System.Threading;
using AutomationFramework.Base;
using OpenQA.Selenium;

namespace BrowserTests.Pages
{
    public class ProductsPage :BasePage
    {
        IWebElement productsContainer = DriverContext.Driver.FindElement(By.XPath("//div[@data-ref = 'tile-grid-container']"));
        public ProductCategoryPage SelectProductCategory(string item)
        {
            try
            {
                switch (item.Trim().ToLower())
                {
                    case "samsung galaxy":
                        //to be implimented when necessary
                        break;
                    case "unlocked mobile phones":
                        //to be implimented when necessary
                        break;
                    case "prepaid mobile phones":
                        //to be implimented when necessary
                        break;
                    case "iphones":
                        IWebElement lnkMobilePhones = productsContainer.FindElement(By.XPath("//a[@title='View the iPhones category']"));
                        lnkMobilePhones.Click();
                        //ToDo : Implicit Fluient wait by writing a Wait utility
                        Thread.Sleep(3000);
                        //ToDo:Check to see if you have navigated to the iphones,if fails retun null and log error
                        break;
                    default:
                        break;
                }
            }
            catch (System.Exception)
            {
                //Log Error
                return null;
            }
            return GetInstance<ProductCategoryPage>();
        }
    }
}
