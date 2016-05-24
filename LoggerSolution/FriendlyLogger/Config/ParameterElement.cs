using System.Configuration;

namespace FriendlyLogger.Config
{
    public class ParameterElement : ConfigurationElement
    {
        private const string KeyAttribute = "key";
        private const string ValueAttribute = "value";

        [ConfigurationProperty(KeyAttribute, IsKey = true, IsRequired = true)]
        public string Key
        {
            get { return (string)this[KeyAttribute]; }
        }

        [ConfigurationProperty(ValueAttribute, IsRequired = true)]
        public string Value
        {
            get { return (string)this[ValueAttribute]; }
        }

    }
}
