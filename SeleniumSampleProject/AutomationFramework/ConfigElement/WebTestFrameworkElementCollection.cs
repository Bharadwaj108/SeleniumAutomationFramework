using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationFramework.ConfigElement
{
    [ConfigurationCollection(typeof(WebTestFrameworkElement), AddItemName = "testSetting", CollectionType = ConfigurationElementCollectionType.BasicMap)]
    public class WebTestFrameworkElementCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new WebTestFrameworkElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return (element as WebTestFrameworkElement).Name;
        }

        public new WebTestFrameworkElement this[string type] => (WebTestFrameworkElement)base.BaseGet(type);
    }
}
