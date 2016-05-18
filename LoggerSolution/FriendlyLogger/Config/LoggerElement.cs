using System.Configuration;

namespace FriendlyLogger.Config
{
    public class LoggerElement : ConfigurationElement
    {
        private const string NameAttribute = "name";
        private const string TypeAttribute = "type";
        private const string LevelsCollection = "levels";

        [ConfigurationProperty(NameAttribute, IsRequired = true, IsKey = true)]
        public string Name
        {
            get { return (string)this[NameAttribute]; }
            set { this[NameAttribute] = value; }
        }

        [ConfigurationProperty(TypeAttribute, IsRequired = true)]
        public string Type
        {
            get { return (string)this[TypeAttribute]; }
            set { this[TypeAttribute] = value; }
        }

        [ConfigurationProperty(LevelsCollection)]
        public LevelElementCollection LevelCollection
        {
            get { return this[LevelsCollection] as LevelElementCollection; }
            set { this[LevelsCollection] = value; }
        }

    }
}
