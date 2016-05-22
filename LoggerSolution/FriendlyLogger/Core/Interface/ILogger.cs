using System;

namespace FriendlyLogger.Core.Interface
{
    public interface ILogger
    {
        string Name { get; }

        void Log(Level level, object message, Exception exception);

        bool IsLevelEnabled(Level level);
    }
}
