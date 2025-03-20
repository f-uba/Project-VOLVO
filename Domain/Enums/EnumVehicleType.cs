using System.ComponentModel;

namespace Domain.Enums
{
    public enum EnumVehicleType
    {
        [Description("Bus")]
        Bus = 0,
        [Description("Car")]
        Car = 1,
        [Description("Truck")]
        Truck = 2
    }
}
