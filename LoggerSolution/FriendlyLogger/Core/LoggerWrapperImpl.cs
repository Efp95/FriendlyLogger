using FriendlyLogger.Core.Interface;
using System.Collections.Generic;

namespace FriendlyLogger.Core
{
    public class LoggerWrapperImpl : ILoggerWrapper
    {
        private readonly IEnumerable<ILogger> _loggerCollection;

        protected LoggerWrapperImpl(IEnumerable<ILogger> logger)
        {
            _loggerCollection = logger;
        }

        public IEnumerable<ILogger> LoggerCollection
        {
            get { return _loggerCollection; }
        }
    }
}
