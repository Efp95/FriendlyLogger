using FriendlyLogger.Core.Interface;
using System;

namespace FriendlyLogger.Core
{
    public abstract class LoggerImpl : ILogger
    {
        private string _name;
        private Level _level;

        protected LoggerImpl(string name, string levelName)
        {
            _name = name;
            //_level = (Level)levelName;
        }

        public string Name
        {
            get { return _name; }
        }
        public Level Level
        {
            get { return _level; }
        }

        public abstract void Log(Type declaringType, Level level, object message, Exception exception);

        public bool IsLevelEnabled(Level level)
        {
            throw new NotImplementedException();
        }
    }
}
