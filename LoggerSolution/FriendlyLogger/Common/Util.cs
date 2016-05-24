using FriendlyLogger.Config;
using FriendlyLogger.Core;
using System;
using System.Collections.Generic;
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

        public static Dictionary<string, string> MapParameterCollectionToDictionary(ParameterElementCollection collection)
        {
            var dictionary = new Dictionary<string, string>();

            ParameterElement param = null;
            foreach (var item in collection)
            {
                param = item as ParameterElement;
                dictionary.Add(param.Key, param.Value);
            }

            return dictionary;
        }
    }
}
