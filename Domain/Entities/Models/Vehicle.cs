using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.Models
{
    public class Vehicle
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public string? Type { get; set; }

        [Required]
        public int NumberOfPassengers { get; set; }

        [Required]
        public string? Color { get; set; }

        [Required]
        public Chassis? Chassis { get; set; }
    }
}
