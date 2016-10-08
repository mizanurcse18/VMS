using System.Configuration;

namespace PS.Infrastructure.Configuration
{
    public class WebConfigApplicationSettings : IApplicationSettings
    {
        public int NumberOfResultsPerPage
        {
            get { return int.Parse(ConfigurationManager.AppSettings["NumberOfResultsPerPage"]); }
        }
        public string LoggerName
        {
            get { return ConfigurationManager.AppSettings["LoggerName"]; }
        }

    }
}
