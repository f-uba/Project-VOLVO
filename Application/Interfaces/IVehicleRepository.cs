using Domain.Entities.Models;

namespace Application.Interfaces
{
    public interface IVehicleRepository : IRepository<Vehicle>
    {
        Vehicle GetByChassisId(Chassis chassisId);
        List<Vehicle> GetAll();
    }
}
