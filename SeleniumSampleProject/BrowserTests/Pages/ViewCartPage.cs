using System.Collections.Generic;
using AutomationFramework.Base;
using OpenQA.Selenium;

namespace BrowserTests.Pages
{
    public class ViewCartPage :BasePage
    {
        IWebElement cartContainer = DriverContext.Driver.FindElement(By.Id("itemDetails"));
        public bool CheckCartItems(string cartItems)
        {
            bool flag = true;
            try
            {
                List<string> cartItemsList = new List<string>(cartItems.Split('|'));
                IList<IWebElement> containerItems = cartContainer.FindElements(By.TagName("a"));
                List<string> missingCartItems = new List<string>();
                foreach (var item in cartItemsList)
                {
                    foreach (var anchors in containerItems)
                    {
                        string anchorText = anchors.Text;
                        if (string.Compare(anchorText, item, true) == 0)
                        {
                            if (flag)
                            flag =  true;
                            break;
                        }
                        else
                        {
                            flag = false;
                        }
                    }
                    if (!flag)//record the missing cart items
                    {
                        missingCartItems.Add(item);
                    }
                }
                if (!flag)
                {
                    //Log error saying that the cart items are missing
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
