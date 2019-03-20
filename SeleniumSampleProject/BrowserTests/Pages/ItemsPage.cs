using System.Threading;
using AutomationFramework.Base;
using OpenQA.Selenium;

namespace BrowserTests.Pages
{
    public class ItemsPage :BasePage
    {
        IWebElement itemsContainer = DriverContext.Driver.FindElement(By.XPath("//div[@data-ref = 'tile-grid-container']"));

        /// <summary>
        /// Select the product from the grid view
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public ProductsPage SelectItem(string item)
        {
            try
            {                
                switch (item.Trim().ToLower())
                {
                    case "audio":
                        //to be implimented when necessary
                        break;
                    case "cameras & drones":
                        //to be implimented when necessary
                        break;
                    case "batteries & power supplies":
                        //to be implimented when necessary
                        break;
                    case "iphones & mobile phones":
                        IWebElement lnkMobilePhones = itemsContainer.FindElement(By.XPath("//a[@title='View the iPhones & Mobile Phones category']"));
                        lnkMobilePhones.Click();
                        //ToDo : Implicit Fluient wait by writing a Wait utility
                        Thread.Sleep(3000);
                        //ToDo:Check to see if you have navigated to the iphones & mobile phones section,if fails retun null and log error
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
            return GetInstance<ProductsPage>();
        }

    }
}
