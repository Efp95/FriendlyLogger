using FriendlyLogger.Core.Interface;

namespace FriendlyLogger.Core
{
    public class LoggerWrapperImpl : ILoggerWrapper
    {
        private readonly ILogger _logger;

        protected LoggerWrapperImpl(ILogger logger)
        {
            _logger = logger;
        }

        public ILogger Logger
        {
            get { return _logger; }
        }
    }
}
