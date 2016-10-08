using System;

namespace PS.Infrastructure.Logging
{
    public enum LogLevel
    {
        Debug,
        Information,
        Warning,
        Error,
        Fatal
    }

    public interface ILogger
    {
        bool IsEnabled(LogLevel level);
        void Log(LogLevel level, Exception exception, string format, params object[] args);
        void Log(LogLevel logLevel, string shortMessage, string fullMessage = "");

        void Debug(string shortMessage, string fullMessage = "");
        void Info(string shortMessage, string fullMessage = "");
        void Warn(string shortMessage, string fullMessage = "");
        void Error(string shortMessage, string fullMessage = "");
        void Fatal(string shortMessage, string fullMessage = "");

        void Debug(Exception exception, string format, params object[] arg);
        void Info(Exception exception, string format, params object[] arg);
        void Warn(Exception exception, string format, params object[] arg);
        void Error(Exception exception, string format, params object[] arg);
        void Fatal(Exception exception, string format, params object[] arg);
    }
}
