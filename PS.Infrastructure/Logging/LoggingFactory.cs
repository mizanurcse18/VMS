namespace PS.Infrastructure.Logging
{
    public class LoggingFactory
    {
        private static ILogger logger;

        public static void InitializeLogFactory(ILogger logger)
        {
            LoggingFactory.logger = logger;
        }

        public static ILogger GetLogger()
        {
            return logger;
        }
    }
}
