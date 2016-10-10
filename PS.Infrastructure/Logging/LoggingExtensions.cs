using System;
using System.Text;

namespace PS.Infrastructure.Logging
{
    public static class LoggingExtensions
    {
        public static void Debug(this ILogger logger, string message, Exception exception = null)
        {
            FilteredLog(logger, LogLevel.Debug, message, exception);
        }
        public static void Information(this ILogger logger, string message, Exception exception = null)
        {
            FilteredLog(logger, LogLevel.Information, message, exception);
        }
        public static void Warning(this ILogger logger, string message, Exception exception = null)
        {
            FilteredLog(logger, LogLevel.Warning, message, exception);
        }
        public static void Error(this ILogger logger, string message, Exception exception = null)
        {
            FilteredLog(logger, LogLevel.Error, message, exception);
        }
        public static void Fatal(this ILogger logger, string message, Exception exception = null)
        {
            FilteredLog(logger, LogLevel.Fatal, message, exception);
        }

        private static void FilteredLog(ILogger logger, LogLevel level, string message, Exception exception = null)
        {
            //don't log thread abort exception
            if ((exception != null) && (exception is System.Threading.ThreadAbortException))
                return;

            if (logger.IsEnabled(level))
            {
                string fullMessage = exception == null ? string.Empty : CreateExceptionMessage(exception);
                logger.Log(level, message, fullMessage);
            }
        }

        private static string CreateExceptionMessage(Exception ex)
        {
            StringBuilder buffer = new StringBuilder();
            buffer.Append(ex.Message).Append(Environment.NewLine);
            buffer.Append("----------").Append(Environment.NewLine);
            buffer.Append(ex.ToString()).Append(Environment.NewLine);
            buffer.Append("----------").Append(Environment.NewLine);
            return buffer.ToString();
        }
    }
}
