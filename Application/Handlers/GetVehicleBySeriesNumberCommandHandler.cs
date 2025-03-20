using Application.Commands;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities.DTOs;
using MediatR;

namespace Application.Handlers
{
    public sealed class GetVehicleBySeriesNumberCommandHandler(IUnitOfWork uof, IMapper mapper) : IRequestHandler<GetVehicleBySeriesNumberCommand, VehicleDto?>
    {
        private readonly IMapper _mapper = mapper;
        private readonly IUnitOfWork _uof = uof;

        public async Task<VehicleDto?> Handle(GetVehicleBySeriesNumberCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var vehicle = await _uof.VehicleRepository.GetBySeriesNumber(request.Series, request.Number);

                if (vehicle != null)
                {
                    var vehicleDto = _mapper.Map<VehicleDto>(vehicle);
                    return vehicleDto;
                }
            }
            catch (Exception)
            {
                throw;
            }

            return null;
        }
    }
}
