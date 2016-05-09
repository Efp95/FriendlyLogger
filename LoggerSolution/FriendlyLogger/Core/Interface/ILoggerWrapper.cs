using System.Collections.Generic;

namespace FriendlyLogger.Core.Interface
{
    public interface ILoggerWrapper
    {
        IEnumerable<ILogger> LoggerCollection { get; }
    }
}
