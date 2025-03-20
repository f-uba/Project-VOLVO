using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.Models
{
    public class Vehicle
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public required string Type { get; set; }

        [Required]
        public required int NumberOfPassangers { get; set; }

        [Required]
        public required string Color { get; set; }


        public required Chassis Chassis { get; set; }
    }
}
