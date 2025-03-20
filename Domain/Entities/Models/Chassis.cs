using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.Models
{
    public sealed class Chassis
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public required string Series { get; set; }

        [Required]
        public required uint Number { get; set; }

        public Guid VehicleId { get; set; }
        public Vehicle? Vehicle { get; set; }
    }
}
