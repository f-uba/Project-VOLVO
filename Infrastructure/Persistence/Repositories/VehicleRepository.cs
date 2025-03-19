using Application.Interfaces;
using Domain.Entities.Models;
using Infrastructure.Persistence.Context;

namespace Infrastructure.Persistence.Repositories
{
    internal sealed class VehicleRepository : Repository<Vehicle>, IVehicleRepository
    {
        public VehicleRepository(AppDbContext context) : base(context) { }

        public List<Vehicle> GetAll()
        {
            throw new NotImplementedException();
        }

        public Vehicle GetByChassisId(Chassis chassisId)
        {
            throw new NotImplementedException();
        }
    }
}
