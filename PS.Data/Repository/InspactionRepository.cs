using PS.Data.Infrastructure;
using PS.Model.Models;

namespace PS.Data.Repository
{
    public class InspactionRepository: RepositoryBase<Inspaction>, IInspactionRepository
    {
        public InspactionRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
        }
    }

    public interface IInspactionRepository : IRepository<Inspaction>
    {
    }
}


