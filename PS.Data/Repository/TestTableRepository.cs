using PS.Data.Infrastructure;
using PS.Model.Models;

namespace PS.Data.Repository
{
    public class TestTableRepository : RepositoryBase<TestTable>, ITestTableRepository
    {
        public TestTableRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
        }
    }

    public interface ITestTableRepository : IRepository<TestTable>
    {
    }
}
