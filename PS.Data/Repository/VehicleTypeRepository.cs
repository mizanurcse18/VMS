using PS.Data.Infrastructure;
using PS.Model.Models;

namespace PS.Data.Repository
{
    public class VehicleTypeRepository: RepositoryBase<VehicleType>, IVehicleTypeRepository
    {
        public VehicleTypeRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
        }
    }

    public interface IVehicleTypeRepository : IRepository<VehicleType>
    {
    }
}


