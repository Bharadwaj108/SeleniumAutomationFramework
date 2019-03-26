using System.Threading;
using AutomationFramework.Base;
using AutomationFramework.Config;
using AutomationFramework.Utils;
using AutomationFramework.Utils.Logger;
using OpenQA.Selenium;

namespace BrowserTests.Pages
{
    public class LoginPage :BasePage
    {
        IWebElement txtUserName = DriverContext.Driver.FindElement(By.Name("username"));        
        IWebElement txtPassword = DriverContext.Driver.FindElement(By.XPath("//input[@data-ref='home-login-password']"));
        IWebElement btnLogin = DriverContext.Driver.FindElement(By.XPath("//button[@data-ref='home-login-button']"));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public HomePage Login(string userName)
        {
            string password = "";
            try
            {
                ExcelUtil.PopulateInCollection(Settings.TestDataLocation + @"\UserLogin.xlsx", "Login");
                //Read the column from the excel data file for the userName
                int rowIndex = ExcelUtil.GetRowNumber("UserName", userName);
                password = ExcelUtil.ReadData(rowIndex, "Password");
                txtUserName.SendKeys(userName);
                txtPassword.SendKeys(password);
                btnLogin.Click();
                //ToDo:Check for successful login
                LogHelper.WriteToLog("Login Successful", AutomationFramework.Utils.Logger.LogType.Info, "SuccessfulLogin");
                Thread.Sleep(2000);
            }
            catch (System.Exception ex)
            {
                CurrentPage = null;
                //Log Error

            }
            return GetInstance<HomePage>();
        }
    }
}
