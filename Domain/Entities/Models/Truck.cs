using Domain.Enums;

namespace Domain.Entities.Models
{
    public sealed class Truck : Vehicle
    {
        public Truck(string series, uint number, string color)
        {
            Chassis = new Chassis
            {
                Series = series,
                Number = number
            };
            Color = color;
            Type = EnumVehicleType.Truck.GetDescription();
            NumberOfPassengers = 1;
        }
    }
}
