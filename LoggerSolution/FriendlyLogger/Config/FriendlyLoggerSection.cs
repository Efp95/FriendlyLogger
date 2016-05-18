using FriendlyLogger.Common;
using System.Configuration;
using System.Xml;

namespace FriendlyLogger.Config
{
    public class FriendlyLoggerSection : ConfigurationSection
    {
        private static FriendlyLoggerSection _configuration =
            ConfigurationManager.GetSection(Parameters.Config.SECTION_NAME) as FriendlyLoggerSection;

        public static FriendlyLoggerSection Configuration
        {
            get { return _configuration; }
        }


        [ConfigurationProperty("loggers")]
        public LoggerElementCollection LoggerCollection
        {
            get
            {
                return this["loggers"] as LoggerElementCollection;
            }
        }

        public void ReadFromXml(XmlDocument document)
        {
            using (XmlReader reader = new XmlNodeReader(document))
            {
                base.DeserializeSection(reader);
            }
        }
    }
}
