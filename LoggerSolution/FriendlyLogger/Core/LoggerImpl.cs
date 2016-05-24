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
        private Dictionary<string, string> _logParameters;

        protected LoggerImpl(string name, IEnumerable<Level> levels, Dictionary<string, string> logParameters)
        {
            _name = name;
            _levels = levels;
            _logParameters = logParameters;
        }

        public string Name
        {
            get { return _name; }
        }
        public IEnumerable<Level> Levels
        {
            get { return _levels; }
        }
        public Dictionary<string, string> LogParameters
        {
            get { return _logParameters; }
        }

        public abstract void Log(Type declaringType, Level level, object message, Dictionary<string, string> logParameters, Exception exception);

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
