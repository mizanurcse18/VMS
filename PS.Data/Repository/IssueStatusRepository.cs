using PS.Data.Infrastructure;
using PS.Model.Models;

namespace PS.Data.Repository
{
    public class IssueStatusRepository: RepositoryBase<IssueStatu>, IIssueStatusRepository
    {
        public IssueStatusRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
        }
    }

    public interface IIssueStatusRepository : IRepository<IssueStatu>
    {
    }
}


