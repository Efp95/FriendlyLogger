using System;
using System.Configuration;

namespace FriendlyLogger.Config
{
    public class ParameterElementCollection : ConfigurationElementCollection
    {
        private string _parameterElementName = "add";


        public ParameterElement this[object key]
        {
            get
            {
                return base.BaseGet(key) as ParameterElement;
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
                return this._parameterElementName;
            }
        }

        protected override bool IsElementName(string elementName)
        {
            bool isName = false;
            if (!String.IsNullOrEmpty(elementName))
                isName = elementName.Equals(this._parameterElementName);
            return isName;
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new ParameterElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((ParameterElement)element).Key;
        }
    }
}
