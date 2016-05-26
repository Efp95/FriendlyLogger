using FriendlyLogger.Common;
using System;
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

        public static FriendlyLoggerSection ReadFromXml(XmlDocument document)
        {
            if (document == null)
                throw new ArgumentNullException("document");

            var configSection = new FriendlyLoggerSection();

            using (XmlReader reader = new XmlNodeReader(document))
            {
                configSection.DeserializeSection(reader);
            }

            return configSection;
        }
    }
}
