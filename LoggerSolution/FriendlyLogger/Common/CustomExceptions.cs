using System;

namespace FriendlyLogger.Common
{
    public class InvalidConfigurationSectionException : Exception
    {
        public InvalidConfigurationSectionException()
        {

        }

        public InvalidConfigurationSectionException(string message)
            : base(message)
        {

        }

        public InvalidConfigurationSectionException(string message, Exception inner)
            : base(message, inner)
        {

        }
    }

    public class InvalidConfigurationElementException : Exception
    {
        public InvalidConfigurationElementException()
        {

        }

        public InvalidConfigurationElementException(string message)
            : base(message)
        {

        }

        public InvalidConfigurationElementException(string message, Exception inner)
            : base(message, inner)
        {

        }
    }
}
