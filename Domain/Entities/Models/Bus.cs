using Domain.Enums;

namespace Domain.Entities.Models
{
    public sealed class Bus : Vehicle
    {
        public Bus(string series, uint number, string color)
        {
            Chassis = new Chassis
            {
                Series = series,
                Number = number
            };
            Color = color;
            Type = EnumVehicleType.Bus.GetDescription();
            NumberOfPassengers = 42;
        }
    }
}
