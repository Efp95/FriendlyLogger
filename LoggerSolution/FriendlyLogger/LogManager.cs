using FriendlyLogger.Common;
using FriendlyLogger.Config;
using FriendlyLogger.Core;
using FriendlyLogger.Core.Interface;
using System;
using System.Collections.Generic;

namespace FriendlyLogger
{
    public sealed class LogManager
    {
        #region [Error Messages]
        private static readonly string NoSectionConfig = "Config Section for " + Parameters.Config.SECTION_NAME + " was not found";
        private const string InvalidTypeDefinition = "Logger type must specify namespace and assembly";
        private const string MustInheritFromLoggerImpl = "Logger type must inherit from LoggerImpl";
        #endregion


        public static ILog GetLogger()
        {
            var configuration = FriendlyLoggerSection.Configuration;

            IEnumerable<ILogger> configLoggers = GetConfigLoggers(configuration);

            return new LogImpl(configLoggers);
        }

        public static ILog GetLogger(System.Xml.XmlDocument configurationFile)
        {
            var configuration = new FriendlyLoggerSection();
            configuration.ReadFromXml(configurationFile);

            IEnumerable<ILogger> configLoggers = GetConfigLoggers(configuration);

            return new LogImpl(configLoggers);
        }


        #region [Private Methods]
        private static IEnumerable<ILogger> GetConfigLoggers(FriendlyLoggerSection configuration)
        {
            List<ILogger> configLoggers = new List<ILogger>();

            if (configuration == null)
                throw new InvalidConfigurationSectionException(NoSectionConfig);

            foreach (LoggerElement logger in configuration.LoggerCollection)
            {
                ILogger loggerInstance = RetrieveLoggerInstance(logger);

                configLoggers.Add(loggerInstance);
            }

            return configLoggers;
        }

        private static ILogger RetrieveLoggerInstance(LoggerElement logger)
        {
            ILogger loggerInstance = null;

            var loggerType = Type.GetType(logger.Type);

            if (loggerType == null)
                throw new InvalidConfigurationElementException(InvalidTypeDefinition);

            if (!typeof(ILogger).IsAssignableFrom(loggerType))
                throw new InvalidConfigurationElementException(MustInheritFromLoggerImpl);

            var levelCollection = LevelMapping.Execute(logger.LevelCollection);

            loggerInstance = (ILogger)Activator.CreateInstance(loggerType, logger.Name, levelCollection);

            return loggerInstance;
        }
        #endregion

    }
}
