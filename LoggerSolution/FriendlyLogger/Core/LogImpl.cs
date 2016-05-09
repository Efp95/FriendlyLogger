using FriendlyLogger.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendlyLogger.Core
{
    public class LogImpl : LoggerWrapperImpl, ILog
    {
        #region [Private Fields]
        private Level _debugLevel = Level.Debug;
        private Level _infoLevel = Level.Info;
        private Level _warnLevel = Level.Warn;
        private Level _errorLevel = Level.Error;
        private Level _fatalLevel = Level.Fatal;
        private Type _declaringType = typeof(LogImpl);
        #endregion


        public LogImpl(ILogger logger) : base(logger)
        {

        }


        #region [Debug Methods]
        public void Debug(object message)
        {
            Debug(message, null);
        }

        public void Debug(object message, Exception exception)
        {
            Logger.Log(_declaringType, _debugLevel, message, exception);
        }

        public void DebugFormat(string format, params object[] args)
        {
            if (Logger.IsLevelEnabled(_debugLevel))
            {
                var formattedText = string.Format(format, args);
                Debug(formattedText);
            }
        }
        #endregion

        #region [Info Methods]
        public void Info(object message)
        {
            Info(message, null);
        }

        public void Info(object message, Exception exception)
        {
            Logger.Log(_declaringType, _infoLevel, message, exception);
        }

        public void InfoFormat(string format, params object[] args)
        {
            if (Logger.IsLevelEnabled(_infoLevel))
            {
                var formattedText = string.Format(format, args);
                Info(formattedText);
            }
        }
        #endregion

        #region [Warn Methods]
        public void Warn(object message)
        {
            Warn(message, null);
        }

        public void Warn(object message, Exception exception)
        {
            Logger.Log(_declaringType, _warnLevel, message, exception);
        }

        public void WarnFormat(string format, params object[] args)
        {
            if (Logger.IsLevelEnabled(_warnLevel))
            {
                var formattedText = string.Format(format, args);
                Warn(formattedText);
            }
        }
        #endregion

        #region [Error Methods]
        public void Error(object message)
        {
            Error(message, null);
        }

        public void Error(object message, Exception exception)
        {
            Logger.Log(_declaringType, _errorLevel, message, exception);
        }

        public void ErrorFormat(string format, params object[] args)
        {
            if (Logger.IsLevelEnabled(_errorLevel))
            {
                var formattedText = string.Format(format, args);
                Error(formattedText);
            }
        }
        #endregion

        #region [Fatal Methods]
        public void Fatal(object message)
        {
            Fatal(message, null);
        }

        public void Fatal(object message, Exception exception)
        {
            Logger.Log(_declaringType, _fatalLevel, message, exception);
        }

        public void FatalFormat(string format, params object[] args)
        {
            if (Logger.IsLevelEnabled(_fatalLevel))
            {
                var formattedText = string.Format(format, args);
                Fatal (formattedText);
            }
        }
        #endregion
    }
}
