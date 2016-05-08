using System;
using System.Configuration;
using System.Xml;

namespace FriendlyLogger.Config
{
    public class LoggerElementCollection : ConfigurationElementCollection
    {
        private string _loggerElementName = "logger";

        public LoggerElement this[object key]
        {
            get
            {
                return base.BaseGet(key) as LoggerElement;
            }
        }

        public override ConfigurationElementCollectionType CollectionType
        {
            get
            {
                return ConfigurationElementCollectionType.BasicMap;
            }
        }

        protected override string ElementName
        {
            get
            {
                return this._loggerElementName;
            }
        }

        protected override bool IsElementName(string elementName)
        {
            bool isName = false;
            if (!String.IsNullOrEmpty(elementName))
                isName = elementName.Equals(this._loggerElementName);
            return isName;
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new LoggerElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((LoggerElement)element).Name;
        }
    }
}
