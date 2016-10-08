using PS.Data.Infrastructure;
using PS.Model.Models;

namespace PS.Data.Repository
{
    public class HREmployeeTypeRepository: RepositoryBase<HREmployeeType>, IHREmployeeTypeRepository
    {
        public HREmployeeTypeRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
        }
    }

    public interface IHREmployeeTypeRepository : IRepository<HREmployeeType>
    {
    }
}


