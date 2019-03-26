using System.Threading;
using AutomationFramework.Base;
using AutomationFramework.Config;
using AutomationFramework.Utils;
using AutomationFramework.Utils.Logger;
using OpenQA.Selenium;

namespace BrowserTests.Pages
{
    public class HomePage : BasePage
    {
        /*IWebElement txtUserName = DriverContext.Driver.FindElement(By.Name("username"));
        //IWebElement txtPassword = DriverContext.Driver.FindElement(By.Name("password"));
        IWebElement txtPassword = DriverContext.Driver.FindElement(By.XPath("//input[@data-ref='home-login-password']"));
        IWebElement btnLogin = DriverContext.Driver.FindElement(By.XPath("//button[@data-ref='home-login-button']"));*/

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
       /* public HomePage Login(string userName)
        {
            string password = "";
            try
            {
                ExcelUtil.PopulateInCollection(Settings.TestDataLocation+ @"\UserLogin.xlsx", "Login");
                //Read the column from the excel data file for the userName
                int rowIndex = ExcelUtil.GetRowNumber("UserName", userName);
                password = ExcelUtil.ReadData(rowIndex, "Password");
                txtUserName.SendKeys(userName);
                txtPassword.SendKeys(password);
                btnLogin.Click();
                //ToDo:Check for successful login
                LogHelper.WriteToLog("Login Successful", AutomationFramework.Utils.Logger.LogType.Info,"SuccessfulLogin");
            }
            catch (System.Exception ex)
            {
                CurrentPage = null;
                //Log Error

            }
            return GetInstance<HomePage>();
        }*/

        /// <summary>
        /// Navigate through the Officeworks main menu on the top of the page
        /// </summary>
        /// <param name="product"></param>        
        /// <returns></returns>
        public ItemsPage NavigateMainMenu(string productCategory)
        {
            try
            {
                IWebElement mainMenuContainer = DriverContext.Driver.FindElement(By.XPath("//div[@data-ref = 'mega-menu-link-technology']"));
                switch (productCategory.Trim().ToLower())
                {
                    case "school essentials":
                        //to be implimented when necessary
                        break;
                    case "office supplies":
                        //to be implimented when necessary
                        break;
                    case "art supplies":
                        //to be implimented when necessary
                        break;
                    case "technology":
                        IWebElement lnkTechnology = mainMenuContainer.FindElement(By.XPath("//a[text()='Technology']"));
                        lnkTechnology.Click();
                        //ToDo : Implicit Fluient wait by writing a Wait utility
                        Thread.Sleep(3000);
                        //ToDo:Check to see if you have navigated to the Technology section,if fails retun null and log error
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
            return GetInstance<ItemsPage>();
        }

    }
}
