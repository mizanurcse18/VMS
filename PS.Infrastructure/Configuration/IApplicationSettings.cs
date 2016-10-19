namespace PS.Infrastructure.Configuration
{
    public interface IApplicationSettings
    {
        int NumberOfResultsPerPage { get; }
        string LoggerName { get; }

    }
}
