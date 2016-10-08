using PS.Data.Infrastructure;
using PS.Model.Models;

namespace PS.Data.Repository
{
    public class InspactionDetailRepository: RepositoryBase<InspactionDetail>, IInspactionDetailRepository
    {
        public InspactionDetailRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
        }
    }

    public interface IInspactionDetailRepository : IRepository<InspactionDetail>
    {
    }
}


