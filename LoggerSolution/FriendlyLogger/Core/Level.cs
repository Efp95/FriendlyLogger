using FriendlyLogger.Common;

namespace FriendlyLogger.Core
{
    public class Level
    {
        #region [Fields]
        private string _name;
        private int _value;
        private string _displayName;
        #endregion

        #region [Properties]
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public int Value
        {
            get { return _value; }
            set { _value = value; }
        }
        public string DisplayName
        {
            get { return _displayName; }
            set { _displayName = value; }
        }
        #endregion

        public Level(int level, string levelName, string displayName)
        {
            _value = level;
            _name = levelName;
            _displayName = displayName;
        }

        public Level(int level, string levelName)
            : this(level, levelName, levelName)
        {
        }


        public readonly static Level[] Levels = {
            //new Level(6000, Parameters.LevelName.ALL),
            new Level(5000, Parameters.LevelName.FATAL),
            new Level(4000, Parameters.LevelName.ERROR),
            new Level(3000, Parameters.LevelName.WARN),
            new Level(2000, Parameters.LevelName.INFO),
            new Level(1000, Parameters.LevelName.DEBUG) 
        };
    }
}
