namespace Domain.Entities.DTOs
{
    public sealed class VehicleDto
    {
        public ChassisDto? ChassisId { get; set; }

        public string? Type { get; set; }

        public int NumberOfPassengers { get; set; }

        public string? Color { get; set; }
    }
}
