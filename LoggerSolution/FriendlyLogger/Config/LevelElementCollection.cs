using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendlyLogger.Config
{
    public class LevelElementCollection : ConfigurationElementCollection
    {
        private string _levelElementName = "level";


        public LevelElement this[object key]
        {
            get
            {
                return base.BaseGet(key) as LevelElement;
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
                return this._levelElementName;
            }
        }

        protected override bool IsElementName(string elementName)
        {
            bool isName = false;
            if (!String.IsNullOrEmpty(elementName))
                isName = elementName.Equals(this._levelElementName);
            return isName;
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new LevelElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((LevelElement)element).Value;
        }
    }
}
