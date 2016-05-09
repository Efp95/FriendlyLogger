using FriendlyLogger.Common;
using FriendlyLogger.Config;
using FriendlyLogger.Core;
using FriendlyLogger.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

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
            List<ILogger> configLoggers = new List<ILogger>();

            var section = FriendlyLoggerSection.Section;
            if (section == null)
                throw new InvalidConfigurationSectionException(NoSectionConfig);

            foreach (LoggerElement logger in section.LoggerCollection)
            {
                var loggerType = Type.GetType(logger.Type);
                if (loggerType == null)
                    throw new InvalidConfigurationElementException(InvalidTypeDefinition);

                if (!typeof(ILogger).IsAssignableFrom(loggerType))
                    throw new InvalidConfigurationElementException(MustInheritFromLoggerImpl);

                var levelCollection = logger.LevelCollection as IEnumerable<Level>;
                var loggerInstance = (ILogger)Activator.CreateInstance(loggerType, levelCollection);

                configLoggers.Add(loggerInstance);
            }

            return new LogImpl(configLoggers);
        }

    }
}
