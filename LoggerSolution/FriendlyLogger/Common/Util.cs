using FriendlyLogger.Core;
using System;
using System.Linq;

namespace FriendlyLogger.Common
{
    public class Util
    {

        public static Level GetLevelByType(string levelTypeName)
        {
            var level = Level.Levels.Where(l => l.Name.Equals(levelTypeName, StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();

            if (level == null)
                throw new ArgumentException("GetLevelByType => levelTypeName");

            return level;
        }

    }
}
