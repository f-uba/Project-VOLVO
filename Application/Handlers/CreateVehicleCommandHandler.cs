using Application.Commands;
using Application.Factory;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Handlers
{
    internal sealed class CreateVehicleCommandHandler(IUnitOfWork uof, IMapper mapper) : IRequestHandler<CreateVehicleCommand, VehicleDto?>
    {
        private readonly IMapper _mapper = mapper;
        private readonly IUnitOfWork _uof = uof;

        public async Task<VehicleDto?> Handle(CreateVehicleCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var vehicle = VehicleFactory.CreateVehicle(request.Series, request.Number, request.Color, request.Type);

                await _uof.VehicleRepository.Add(vehicle);
                await _uof.Commit();

                return _mapper.Map<VehicleDto>(vehicle);
            }
            catch (DbUpdateException ex)
            {
                throw new InvalidOperationException("Already have a vehicle with this series and number.", ex);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
