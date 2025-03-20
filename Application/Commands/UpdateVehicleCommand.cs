using Domain.Entities.DTOs;
using MediatR;

namespace Application.Commands
{
    public sealed class UpdateVehicleCommand : IRequest<VehicleDto>
    {
        public required string Series { get; set; }
        public required uint Number { get; set; }
        public required string Color { get; set; }
    }
}
