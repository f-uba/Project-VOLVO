using System.Text.Json.Serialization;
using Domain.Enums;

namespace Domain.Entities.DTOs
{
    public sealed class VehicleDto
    {
        public ChassisDto? ChassisId { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public EnumVehicleType Type { get; set; }

        public int NumberOfPassangers => (int)Type;

        public string? Color { get; set; }
    }
}
 