using System;
using log4net;
using log4net.Config;
using PS.Infrastructure.Configuration;

namespace PS.Infrastructure.Logging
{
    /// <summary>
    /// Log4Net implementation for logger
    /// </summary>
    public class Log4NetLogger : ILogger
    {
        private readonly log4net.ILog log;

        public Log4NetLogger()
        {
            XmlConfigurator.Configure();
            log = LogManager.GetLogger(ApplicationSettingsFactory.GetApplicationSettings().LoggerName);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="level"></param>
        /// <returns></returns>
        public bool IsEnabled(LogLevel level)
        {
            switch (level)
            {
                case LogLevel.Debug:
                    return log.IsDebugEnabled;
                case LogLevel.Information:
                    return log.IsInfoEnabled;
                case LogLevel.Warning:
                    return log.IsWarnEnabled;
                case LogLevel.Error:
                    return log.IsErrorEnabled;
                case LogLevel.Fatal:
                    return log.IsFatalEnabled;
            }
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="level"></param>
        /// <param name="exception"></param>
        /// <param name="format"></param>
        /// <param name="args"></param>
        public void Log(LogLevel level, System.Exception exception, string format, params object[] args)
        {
            if (args == null)
            {
                switch (level)
                {
                    case LogLevel.Debug:
                        log.Debug(format, exception);
                        break;
                    case LogLevel.Information:
                        log.Info(format, exception);
                        break;
                    case LogLevel.Warning:
                        log.Warn(format, exception);
                        break;
                    case LogLevel.Error:
                        log.Error(format, exception);
                        break;
                    case LogLevel.Fatal:
                        log.Fatal(format, exception);
                        break;
                }
            }
            else
            {
                switch (level)
                {
                    case LogLevel.Debug:
                        log.DebugFormat(format, exception, args);
                        break;
                    case LogLevel.Information:
                        log.InfoFormat(format, exception, args);
                        break;
                    case LogLevel.Warning:
                        log.WarnFormat(format, exception, args);
                        break;
                    case LogLevel.Error:
                        log.ErrorFormat(format, exception, args);
                        break;
                    case LogLevel.Fatal:
                        log.FatalFormat(format, exception, args);
                        break;
                }
            }
        }


        public void Log(LogLevel level, string shortMessage, string fullMessage = "")
        {
            switch (level)
            {
                case LogLevel.Debug:
                    log.Debug(string.Format("{0} {1}", shortMessage, fullMessage));
                    break;
                case LogLevel.Information:
                    log.Info(string.Format("{0} {1}", shortMessage, fullMessage));
                    break;
                case LogLevel.Warning:
                    log.Warn(string.Format("{0} {1}", shortMessage, fullMessage));
                    break;
                case LogLevel.Error:
                    log.Error(string.Format("{0} {1}", shortMessage, fullMessage));
                    break;
                case LogLevel.Fatal:
                    log.Fatal(string.Format("{0} {1}", shortMessage, fullMessage));
                    break;
            }

        }


        public void Debug(string shortMessage, string fullMessage = "")
        {
            Log(LogLevel.Debug, shortMessage, fullMessage);
        }

        public void Info(string shortMessage, string fullMessage = "")
        {
            Log(LogLevel.Information, shortMessage, fullMessage);
        }
        
        public void Warn(string shortMessage, string fullMessage = "")
        {
            Log(LogLevel.Warning, shortMessage, fullMessage);
        }
        public void Error(string shortMessage, string fullMessage = "")
        {
            Log(LogLevel.Error, shortMessage, fullMessage);
        }

        public void Fatal(string shortMessage, string fullMessage = "")
        {
            Log(LogLevel.Fatal, shortMessage, fullMessage); 
        }

        public void Debug(Exception exception, string format, params object[] arg)
        {
            Log(LogLevel.Debug, exception, format, arg);
        }

        public void Info(Exception exception, string format, params object[] arg)
        {
            Log(LogLevel.Information, exception, format, arg);
        }

        public void Warn(Exception exception, string format, params object[] arg)
        {
            Log(LogLevel.Warning, exception, format, arg);
        }

        public void Error(Exception exception, string format, params object[] arg)
        {
            Log(LogLevel.Error, exception, format, arg);
        }
            
        public void Fatal(Exception exception, string format, params object[] arg)
        {
            Log(LogLevel.Fatal, exception, format, arg);
        }
    }
}
