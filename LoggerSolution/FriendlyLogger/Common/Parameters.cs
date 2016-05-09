
namespace FriendlyLogger.Common
{
    public class Parameters
    {
        public struct Config
        {
            public static string SECTION_NAME = "friendlyLogger";
        }

        public struct LevelName
        {
            public const string ALL = "ALL";
            public const string DEBUG = "DEBUG";
            public const string INFO = "INFO";
            public const string WARN = "WARN";
            public const string ERROR = "ERROR";
            public const string FATAL = "FATAL";
        }
    }
}
