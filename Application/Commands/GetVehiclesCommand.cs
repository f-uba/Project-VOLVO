using Domain.Entities.DTOs;
using MediatR;

namespace Application.Commands
{
    public sealed class GetVehiclesCommand : IRequest<ICollection<VehicleDto>>
    {
    }
}
