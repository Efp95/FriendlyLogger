using FriendlyLogger.Common;
using FriendlyLogger.Config;
using System;
using System.Collections.Generic;

namespace FriendlyLogger.Core
{
    public class Level
    {
        #region [Fields]
        private string _name;
        private int _value;
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
        #endregion


        public Level(int level, string levelName)
        {
            _value = level;
            _name = levelName;
        }


        public readonly static Level[] Levels = {
            new Level(6000, Parameters.LevelName.ALL),
            new Level(5000, Parameters.LevelName.FATAL),
            new Level(4000, Parameters.LevelName.ERROR),
            new Level(3000, Parameters.LevelName.WARN),
            new Level(2000, Parameters.LevelName.INFO),
            new Level(1000, Parameters.LevelName.DEBUG) 
        };
    }

    public class LevelMapping
    {

        public static IEnumerable<Level> Execute(LevelElementCollection levelElementCollection)
        {
            List<Level> level = new List<Level>();

            if (levelElementCollection == null)
                level.Add(Util.GetLevelByType(Parameters.LevelName.DEBUG));
            else
            {
                foreach (LevelElement levelElement in levelElementCollection)
                {
                    level.Add(Util.GetLevelByType(levelElement.Value));
                }
            }

            return level;
        }
    }
}
