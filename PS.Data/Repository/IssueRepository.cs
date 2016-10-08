using PS.Data.Infrastructure;
using PS.Model.Models;

namespace PS.Data.Repository
{
    public class IssueRepository: RepositoryBase<Issue>, IIssueRepository
    {
        public IssueRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
        }
    }

    public interface IIssueRepository : IRepository<Issue>
    {
    }
}


