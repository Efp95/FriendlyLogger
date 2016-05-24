using System;
using System.Collections.Generic;

namespace FriendlyLogger.Core.Interface
{
    public interface ILogger
    {
        string Name { get; }
        Dictionary<string, string> LogParameters { get; }

        void Log(Type declaringType, Level level, object message, Dictionary<string, string> logParameters, Exception exception);

        bool IsLevelEnabled(Level level);
    }
}
