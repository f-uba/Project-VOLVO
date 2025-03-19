using Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.Models
{
    public sealed class Vehicle
    {
        [Key]
        public required Chassis ChassisId { get; set; }

        [Required]
        public required EnumVehicleType Type { get; set; }

        [NotMapped]
        public int Passangers => (int)Type;

        [Required]
        public required string Color { get; set; }
    }
}
