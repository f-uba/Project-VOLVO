using Application.Commands;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities.DTOs;
using Domain.Entities.Models;
using MediatR;

namespace Application.Handlers
{
    public sealed class CreateVehicleCommandHandler(IUnitOfWork uof, IMapper mapper) : IRequestHandler<CreateVehicleCommand, VehicleDto?>
    {
        private readonly IMapper _mapper = mapper;
        private readonly IUnitOfWork _uof = uof;

        public async Task<VehicleDto?> Handle(CreateVehicleCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var vehicle = new Vehicle
                {
                    Chassis = new Chassis
                    {
                        Series = request.Series,
                        Number = request.Number
                    },
                    NumberOfPassangers = (int)request.Type,
                    Type = request.Type.GetDescription(),
                    Color = request.Color
                };

                _uof.VehicleRepository.Add(vehicle);
                await _uof.Commit();

                return _mapper.Map<VehicleDto>(vehicle);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
