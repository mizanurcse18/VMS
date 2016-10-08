using PS.Data.Infrastructure;
using PS.Model.Models;

namespace PS.Data.Repository
{
    public class BrandRepository: RepositoryBase<Brand>, IBrandRepository
    {
        public BrandRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
        }
    }

    public interface IBrandRepository : IRepository<Brand>
    {
    }
}


