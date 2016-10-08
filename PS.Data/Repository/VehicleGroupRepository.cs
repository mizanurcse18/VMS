using PS.Data.Infrastructure;
using PS.Model.Models;

namespace PS.Data.Repository
{
    public class VehicleGroupRepository: RepositoryBase<VehicleGroup>, IVehicleGroupRepository
    {
        public VehicleGroupRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
        }
    }

    public interface IVehicleGroupRepository : IRepository<VehicleGroup>
    {
    }
}


