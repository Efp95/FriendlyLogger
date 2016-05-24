using FriendlyLogger.Common;
using FriendlyLogger.Core.Interface;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace FriendlyLogger.Core
{
    public sealed class LogImpl : LoggerWrapperImpl, ILog
    {
        #region [Private Fields]
        // Skips to Calling Context
        private const int SkippedFrames = 2;
        private Type _declaringType;

        private Level _debugLevel = Util.GetLevelByType(Parameters.LevelName.DEBUG);
        private Level _infoLevel = Util.GetLevelByType(Parameters.LevelName.INFO);
        private Level _warnLevel = Util.GetLevelByType(Parameters.LevelName.WARN);
        private Level _errorLevel = Util.GetLevelByType(Parameters.LevelName.ERROR);
        private Level _fatalLevel = Util.GetLevelByType(Parameters.LevelName.FATAL);
        #endregion

        public LogImpl(IEnumerable<ILogger> loggerCollection)
            : base(loggerCollection)
        {
            _declaringType = new StackFrame(SkippedFrames).GetMethod().ReflectedType;
        }


        #region [Debug Methods]
        public void Debug(object message)
        {
            Debug(message, null);
        }

        public void Debug(object message, Exception exception)
        {
            foreach (var logger in LoggerCollection)
            {
                if (logger.IsLevelEnabled(_debugLevel))
                {
                    logger.Log(_declaringType, _debugLevel, message, exception);
                }
            }
        }

        public void DebugFormat(string format, params object[] args)
        {
            var formattedText = string.Format(format, args);
            Debug(formattedText);
        }
        #endregion

        #region [Info Methods]
        public void Info(object message)
        {
            Info(message, null);
        }

        public void Info(object message, Exception exception)
        {
            foreach (var logger in LoggerCollection)
            {
                if (logger.IsLevelEnabled(_infoLevel))
                {
                    logger.Log(_declaringType, _infoLevel, message, exception);
                }
            }
        }

        public void InfoFormat(string format, params object[] args)
        {
            var formattedText = string.Format(format, args);
            Info(formattedText);
        }
        #endregion

        #region [Warn Methods]
        public void Warn(object message)
        {
            Warn(message, null);
        }

        public void Warn(object message, Exception exception)
        {
            foreach (var logger in LoggerCollection)
            {
                if (logger.IsLevelEnabled(_warnLevel))
                {
                    logger.Log(_declaringType, _warnLevel, message, exception);
                }
            }
        }

        public void WarnFormat(string format, params object[] args)
        {
            var formattedText = string.Format(format, args);
            Warn(formattedText);
        }
        #endregion

        #region [Error Methods]
        public void Error(object message)
        {
            Error(message, null);
        }

        public void Error(object message, Exception exception)
        {
            foreach (var logger in LoggerCollection)
            {
                if (logger.IsLevelEnabled(_errorLevel))
                {
                    logger.Log(_declaringType, _errorLevel, message, exception);
                }
            }
        }

        public void ErrorFormat(string format, params object[] args)
        {
            var formattedText = string.Format(format, args);
            Error(formattedText);
        }
        #endregion

        #region [Fatal Methods]
        public void Fatal(object message)
        {
            Fatal(message, null);
        }

        public void Fatal(object message, Exception exception)
        {
            foreach (var logger in LoggerCollection)
            {
                if (logger.IsLevelEnabled(_fatalLevel))
                {
                    logger.Log(_declaringType, _fatalLevel, message, exception);
                }
            }
        }

        public void FatalFormat(string format, params object[] args)
        {
            var formattedText = string.Format(format, args);
            Fatal(formattedText);
        }
        #endregion
    }
}
