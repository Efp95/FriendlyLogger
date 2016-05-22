using FriendlyLogger.Common;
using FriendlyLogger.Core;
using System;
using System.Collections.Generic;

namespace FriendlyLogger.Logger
{
    public class ConsoleLogger : LoggerImpl
    {
        public ConsoleLogger(string name, IEnumerable<Level> levels)
            : base(name, levels)
        {
        }

        public override void Log(Level level, object message, Exception exception)
        {
            var colorSettings = new ConsoleColorManager(level);

            Console.ForegroundColor = colorSettings.Foreground;
            Console.BackgroundColor = colorSettings.Background;

            if (exception == null)
                Console.WriteLine(message);
            else
                Console.WriteLine("Error: {0}", exception.HResult, message);

            Console.BackgroundColor = ConsoleColorManager.GetDefaultForeground();
        }
    }

    public class ConsoleColorManager
    {
        private ConsoleColor _background;
        private ConsoleColor _foreground;


        public ConsoleColorManager(Level level)
        {
            _background = ConsoleColor.Black;
            _foreground = ManageForeGround(level);
        }

        public ConsoleColor Foreground
        {
            get { return _foreground; }
            set { _foreground = value; }
        }
        public ConsoleColor Background
        {
            get { return _background; }
            set { _background = value; }
        }

        private ConsoleColor ManageForeGround(Level level)
        {
            switch (level.Name)
            {
                case Parameters.LevelName.INFO: return ConsoleColor.White;
                case Parameters.LevelName.DEBUG: return ConsoleColor.Blue;
                case Parameters.LevelName.WARN: return ConsoleColor.Yellow;
                case Parameters.LevelName.ERROR: return ConsoleColor.DarkRed;
                case Parameters.LevelName.FATAL: return ConsoleColor.Red;
                default: return default(ConsoleColor);
            }
        }

        public static ConsoleColor GetDefaultForeground()
        {
            return ConsoleColor.White;
        }

    }
}
