using Domain.Entities.DTOs;
using MediatR;

namespace Application.Commands
{
    public sealed class GetVehicleBySeriesNumberCommand : IRequest<VehicleDto>
    {
        public required string Series { get; set; }
        public uint Number { get; set; }
    }
}
