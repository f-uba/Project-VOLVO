using Application.Commands;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities.DTOs;
using MediatR;

namespace Application.Handlers
{
    internal sealed class GetVehiclesCommandHandler(IUnitOfWork uof, IMapper mapper) : IRequestHandler<GetVehiclesCommand, ICollection<VehicleDto>?>
    {
        private readonly IMapper _mapper = mapper;
        private readonly IUnitOfWork _uof = uof;

        public async Task<ICollection<VehicleDto>?> Handle(GetVehiclesCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var vehiclesList = await _uof.VehicleRepository.GetAll();
                if (vehiclesList.Any())
                {
                    var vehiclesDtoList = _mapper.Map<ICollection<VehicleDto>>(vehiclesList);
                    return vehiclesDtoList;
                }
            }
            catch (Exception)
            {
                throw;
            }

            return [];
        }
    }
}
