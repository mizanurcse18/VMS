using System;

namespace PS.Data.Infrastructure
{
    public interface IDatabaseFactory : IDisposable
    {
        ApplicationEntities Get();
    }
}
