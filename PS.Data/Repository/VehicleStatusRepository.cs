using PS.Data.Infrastructure;
using PS.Model.Models;

namespace PS.Data.Repository
{
    public class VehicleStatusRepository: RepositoryBase<VehicleStatu>, IVehicleStatusRepository
    {
        public VehicleStatusRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
        }
    }

    public interface IVehicleStatusRepository : IRepository<VehicleStatu>
    {
    }
}


