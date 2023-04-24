using AlpTrips.Application.Dtos;
using AlpTrips.Application.Trip.Commands.EditTrip;
using AlpTrips.Domain.Entities;
using AutoMapper;

namespace AlpTrips.Application.Mappings
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {
            CreateMap<TripDto, Domain.Entities.Trip>().ForMember(p => p.User, opt => opt.MapFrom(src => new User()
            {
                Name = src.UserName,
                Email = src.Email
            }));

            CreateMap<Domain.Entities.Trip, TripDto>()
                .ForMember(dto =>dto.UserName, opt =>opt.MapFrom(src =>src.User.Name))
                .ForMember(dto => dto.Email, opt => opt.MapFrom(src => src.User.Email));

            CreateMap<TripDto, EditTripCommand>();

        }
    }
}
