using System.Configuration;

namespace FriendlyLogger.Config
{
    public class LevelElement : ConfigurationElement
    {
        private const string ValueAttribute = "value";

        [ConfigurationProperty(ValueAttribute, IsKey = true, IsRequired = true)]
        public string Value
        {
            get { return (string)this[ValueAttribute]; }
        }
    }
}
