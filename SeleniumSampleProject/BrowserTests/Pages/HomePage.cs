using AutomationFramework.Base;
using AutomationFramework.Config;
using AutomationFramework.Utils;
using OpenQA.Selenium;

namespace BrowserTests.Pages
{
    public class HomePage : BasePage
    {
        IWebElement txtUserName = DriverContext.Driver.FindElement(By.Name("username"));
        IWebElement txtPassword = DriverContext.Driver.FindElement(By.Name("password"));
        IWebElement btnLogin = DriverContext.Driver.FindElement(By.XPath("//label[text()='Log in']"));

        public HomePage Login(string userName)
        {
            string password = "";
            try
            {
                ExcelUtil.PopulateInCollection(Settings.TestDataLocation+ @"\UserLogin.xlsx", "Login");
                //Read the column from the excel data file for the userName
                int rowIndex = ExcelUtil.GetRowNumber("UserName", "bharadwaj54@yahoo.com");
                password = ExcelUtil.ReadData(rowIndex, "Password");
                txtUserName.SendKeys("userName");
                txtUserName.SendKeys("password");
                btnLogin.Click();
            }
            catch (System.Exception ex)
            {
                //Log Error

            }
            return GetInstance<HomePage>();
        }
    }
}
