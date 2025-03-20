using Domain.Entities.DTOs;
using Domain.Enums;
using MediatR;

namespace Application.Commands
{
    public sealed class CreateVehicleCommand : IRequest<VehicleDto>
    {
        public required string Series { get; set; }
        public required uint Number { get; set; }
        public EnumVehicleType Type { get; set; }
        public required string Color { get; set; }
    }
}
