﻿using System.Configuration;

namespace FriendlyLogger.Config
{
    public class LevelElement : ConfigurationElement
    {
        private const string ValueAttribute = "value";

        [ConfigurationProperty(ValueAttribute)]
        public string Value
        {
            get { return (string)this[ValueAttribute]; }
        }
    }
}
