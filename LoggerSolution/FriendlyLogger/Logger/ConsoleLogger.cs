using FriendlyLogger.Core;
using System;

namespace FriendlyLogger.Logger
{
    public class ConsoleLogger : LoggerImpl
    {
        public ConsoleLogger(string name, string levelName) : base(name, levelName)
        {
        }

        public override void Log(Type declaringType, Level level, object message, Exception exception)
        {
            throw new NotImplementedException();
        }
    }
}
