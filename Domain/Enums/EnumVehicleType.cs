using System.ComponentModel;

namespace Domain.Enums
{
    public enum EnumVehicleType
    {
        [Description("Bus")]
        Bus = 42,
        [Description("Car")]
        Car = 4,
        [Description("Truck")]
        Truck = 1
    }
}
