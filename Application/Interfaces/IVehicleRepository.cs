using Domain.Entities.Models;

namespace Application.Interfaces
{
    public interface IVehicleRepository : IRepository<Vehicle>
    {
        Task<IEnumerable<Vehicle>> GetAll();
        Task<Vehicle?> GetBySeriesNumber(string series, uint number);
    }
}
