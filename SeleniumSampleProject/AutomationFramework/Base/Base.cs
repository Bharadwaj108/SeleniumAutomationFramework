using System;
using TechTalk.SpecFlow;

namespace AutomationFramework.Base
{
    public class Base
    {
        public BasePage CurrentPage
        {
            get => (BasePage)ScenarioContext.Current["currentPage"];
            set => ScenarioContext.Current["currentPage"] = value;
        }

        protected TPage GetInstance<TPage>() where TPage : BasePage, new() => (TPage)Activator.CreateInstance(typeof(TPage));

        public TPage As<TPage>() where TPage : BasePage => (TPage)this;
    }
}
