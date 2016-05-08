using FriendlyLogger.Common;
using System.Configuration;

namespace FriendlyLogger.Config
{
    public class FriendlyLoggerSection : ConfigurationSection
    {
        private static FriendlyLoggerSection _configuration =
            ConfigurationManager.GetSection(Parameters.Config.SECTION_NAME) as FriendlyLoggerSection;

        public static FriendlyLoggerSection Section
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
    }
}
