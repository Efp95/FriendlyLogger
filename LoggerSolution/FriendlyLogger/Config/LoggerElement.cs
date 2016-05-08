using System.Configuration;

namespace FriendlyLogger.Config
{
    public class LoggerElement : ConfigurationElement
    {
        private const string NameAttribute = "name";
        private const string TypeAttribute = "type";

        [ConfigurationProperty(NameAttribute, IsRequired = true, IsKey = true)]
        public string Name
        {
            get { return (string)this[NameAttribute]; }
        }

        [ConfigurationProperty(TypeAttribute, IsRequired = true)]
        public string Type
        {
            get { return (string)this[TypeAttribute]; }
        }
    }
}
