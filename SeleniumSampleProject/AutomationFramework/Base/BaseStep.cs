using AutomationFramework.Config;
using AutomationFramework.Utils.Logger;

namespace AutomationFramework.Base
{
    public class BaseStep : Base
    {
        public virtual void NaviateSite()
        {
            DriverContext.Browser.GoToUrl(Settings.AUT);
            LogHelper.WriteToLog("Opened the browser !!!");
        }
    }
}
