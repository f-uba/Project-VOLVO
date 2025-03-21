using Domain.Entities.Models;
using Infrastructure.Persistence.Context;

namespace xUnitTests
{
    public sealed class DBUnitTestsMockInitializer
    {
        private readonly AppDbContext _context;

        public DBUnitTestsMockInitializer(AppDbContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            _context.Vehicles.Add(
                new Vehicle { Color = "Blue", Type = "Truck", NumberOfPassengers = 1, Chassis = new Chassis { Series = "A", Number = 1 } });

            _context.Vehicles.Add(
                new Vehicle { Color = "Red", Type = "Car", NumberOfPassengers = 4, Chassis = new Chassis { Series = "A", Number = 2 } });

            _context.Vehicles.Add(
                new Vehicle { Color = "White", Type = "Bus", NumberOfPassengers = 42, Chassis = new Chassis { Series = "A", Number = 3 } });

            _context.Vehicles.Add(
                new Vehicle { Color = "Green", Type = "Truck", NumberOfPassengers = 1, Chassis = new Chassis { Series = "B", Number = 1 } });

            _context.Vehicles.Add(
                new Vehicle { Color = "Orange", Type = "Car", NumberOfPassengers = 4, Chassis = new Chassis { Series = "B", Number = 2 } });

            _context.Vehicles.Add(
                new Vehicle { Color = "Black", Type = "Bus", NumberOfPassengers = 42, Chassis = new Chassis { Series = "B", Number = 3 } });

            _context.SaveChanges();
        }
    }
}
