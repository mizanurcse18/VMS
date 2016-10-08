using PS.Data.Infrastructure;
using PS.Model.Models;

namespace PS.Data.Repository
{
    public class VendorRepository: RepositoryBase<Vendor>, IVendorRepository
    {
        public VendorRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
        }
    }

    public interface IVendorRepository : IRepository<Vendor>
    {
    }
}


