using Domain.Entities.Models;

namespace Application.Interfaces
{
    public interface IVehicleRepository : IRepository<Vehicle>
    {
        Vehicle? GetBySeriesNumber(string series, uint number);
    }
}
