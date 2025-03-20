using Domain.Enums;

namespace Domain.Entities.Models
{
    public sealed class Car : Vehicle
    {
        public Car(string series, uint number, string color)
        {
            Chassis = new Chassis
            {
                Series = series,
                Number = number
            };
            Color = color;
            Type = EnumVehicleType.Car.GetDescription();
            NumberOfPassengers = 4;
        }
    }
}
