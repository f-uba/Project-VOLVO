using Application.Interfaces;
using Infrastructure.Persistence.Context;
using Infrastructure.Persistence.Repositories;

namespace Infrastructure.Persistence.UnitOfWork
{
    public sealed class UnitOfWork(AppDbContext context) : IUnitOfWork
    {
        public AppDbContext _context = context;

        public required IVehicleRepository _vehicleRepository;
        public IVehicleRepository VehicleRepository => _vehicleRepository ??= new VehicleRepository(_context);

        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
