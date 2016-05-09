using FriendlyLogger.Core;
using System;
using System.Collections.Generic;
using System.IO;

namespace FriendlyLogger.Logger
{
    public class FileLogger : LoggerImpl
    {

        public FileLogger(string name, IEnumerable<Level> levels)
            : base(name, levels)
        {
        }

        public override void Log(Type declaringType, Level level, object message, Exception exception)
        {
            if (exception == null)
            {
                WriteFile(message);
            }
            else
            {
                string text = string.Format("Error: {0}", exception.HResult, message);
                WriteFile(text);
            }
        }

        private void WriteFile(object message)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory;

            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.WriteLine(message);
            }
        }
    }
}
