using Domain.Entities.Models;
using Domain.Enums;

namespace Application.Factory
{
    public static class VehicleFactory
    {
        public static Vehicle CreateVehicle(string series, uint number, string color, EnumVehicleType vehicleType)
        {
            return vehicleType switch
            {
                EnumVehicleType.Truck => new Truck(series, number, color),
                EnumVehicleType.Bus => new Bus(series, number, color),
                EnumVehicleType.Car => new Car(series, number, color),
                _ => throw new ArgumentException("Unsuported vehicle type.", nameof(vehicleType))
            };
        }
    }
}
