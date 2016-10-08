namespace PS.Infrastructure.Configuration
{
    public class ApplicationSettingsFactory
    {
        private static IApplicationSettings applicationSettings;

        public static void InitializeApplicationSettingsFactory(IApplicationSettings appSettings)
        {
            applicationSettings = appSettings;
        }

        public static IApplicationSettings GetApplicationSettings()
        {
            return applicationSettings;
        }
    }
}