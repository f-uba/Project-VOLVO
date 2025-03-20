using AutoMapper;
using Domain.Entities.DTOs;
using Domain.Entities.Models;

namespace Application.Mapper
{
    public sealed class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Vehicle, VehicleDto>()
                .ForMember(dest => dest.ChassisId, opt => opt.MapFrom(src => src.Chassis));

            CreateMap<Chassis, ChassisDto>();
        }
    }
}
