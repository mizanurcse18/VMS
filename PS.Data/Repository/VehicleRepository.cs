using PS.Data.Infrastructure;
using PS.Model.Models;

namespace PS.Data.Repository
{
    public class VehicleRepository: RepositoryBase<Vehicle>, IVehicleRepository
    {
        public VehicleRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
        }
    }

    public interface IVehicleRepository : IRepository<Vehicle>
    {
    }
}


