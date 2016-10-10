using PS.Data.Infrastructure;
using PS.Model.Models;

namespace PS.Data.Repository
{
    public class HREmployeeRepository: RepositoryBase<HREmployee>, IHREmployeeRepository
    {
        public HREmployeeRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
        }
    }

    public interface IHREmployeeRepository : IRepository<HREmployee>
    {
    }
}


