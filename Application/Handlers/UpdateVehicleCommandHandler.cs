using Application.Commands;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities.DTOs;
using MediatR;

namespace Application.Handlers
{
    public sealed class UpdateVehicleCommandHandler(IUnitOfWork uof, IMapper mapper) : IRequestHandler<UpdateVehicleCommand, VehicleDto?>
    {
        private readonly IMapper _mapper = mapper;
        private readonly IUnitOfWork _uof = uof;

        public async Task<VehicleDto?> Handle(UpdateVehicleCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var vehicle = await _uof.VehicleRepository.GetBySeriesNumber(request.Series, request.Number);
                if (vehicle != null)
                {
                    vehicle.Color = request.Color;
                    _uof.VehicleRepository.Update(vehicle);
                    await _uof.Commit();

                    return _mapper.Map<VehicleDto>(vehicle);
                }

                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
