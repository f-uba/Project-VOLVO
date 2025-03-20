using Application.Interfaces;
using Domain.Entities.Models;
using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    internal sealed class VehicleRepository(AppDbContext context) : Repository<Vehicle>(context), IVehicleRepository
    {
        public override IQueryable<Vehicle> Get()
        {
            return _context.Set<Vehicle>()
                .AsNoTracking()
                .Include(v => v.Chassis);
        }

        public Vehicle? GetBySeriesNumber(string series, uint number)
        {
            return Get().FirstOrDefault(v => v.Chassis.Series == series && v.Chassis.Number == number);
        }
    }
}

