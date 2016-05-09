using FriendlyLogger.Core;
using System;
using System.Collections.Generic;

namespace FriendlyLogger.Logger
{
    public class ConsoleLogger : LoggerImpl
    {
        public ConsoleLogger(string name, IEnumerable<Level> levels)
            : base(name, levels)
        {
        }

        public override void Log(Type declaringType, Level level, object message, Exception exception)
        {
            throw new NotImplementedException();
        }
    }
}
