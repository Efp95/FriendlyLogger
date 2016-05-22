using FriendlyLogger.Common;
using FriendlyLogger.Core.Interface;
using System;
using System.Linq;
using System.Collections.Generic;

namespace FriendlyLogger.Core
{
    public abstract class LoggerImpl : ILogger
    {
        private string _name;
        private IEnumerable<Level> _levels;

        protected LoggerImpl(string name, IEnumerable<Level> Levels)
        {
            _name = name;
            _levels = Levels;
        }

        public string Name
        {
            get { return _name; }
        }
        public IEnumerable<Level> Levels
        {
            get { return _levels; }
        }

        public abstract void Log(Level level, object message, Exception exception);

        public bool IsLevelEnabled(Level level)
        {
            var allLevels = Util.GetLevelByType(Parameters.LevelName.ALL);

            if (Levels.Contains(allLevels))
            {
                return true;
            }
            else
            {
                // Enables DEBUG log by default
                if (!Levels.Any() && level.Name.Equals(Parameters.LevelName.DEBUG))
                    return true;

                return Levels.Contains(level);
            }
        }
    }
}
