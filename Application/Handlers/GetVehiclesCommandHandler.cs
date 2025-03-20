using Application.Commands;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities.DTOs;
using MediatR;

namespace Application.Handlers
{
    public sealed class GetVehiclesCommandHandler(IUnitOfWork uof, IMapper mapper) : IRequestHandler<GetVehiclesCommand, ICollection<VehicleDto>?>
    {
        private readonly IMapper _mapper = mapper;
        private readonly IUnitOfWork _uof = uof;

        public Task<ICollection<VehicleDto>?> Handle(GetVehiclesCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var vehiclesList = _uof.VehicleRepository.Get().ToList();
                if (vehiclesList.Any())
                {
                    var vehiclesDtoList = _mapper.Map<ICollection<VehicleDto>>(vehiclesList);
                    return Task.FromResult<ICollection<VehicleDto>?>(vehiclesDtoList);
                }
            }
            catch (Exception)
            {
                throw;
            }

            return Task.FromResult<ICollection<VehicleDto>?>([]);
        }
    }
}
