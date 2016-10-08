using PS.Data.Infrastructure;
using PS.Model.Models;

namespace PS.Data.Repository
{
    public class VendorTypeRepository: RepositoryBase<VendorType>, IVendorTypeRepository
    {
        public VendorTypeRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
        }
    }

    public interface IVendorTypeRepository : IRepository<VendorType>
    {
    }
}


