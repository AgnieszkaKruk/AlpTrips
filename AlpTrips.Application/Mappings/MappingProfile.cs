using AlpTrips.Application.Dtos;
using AlpTrips.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlpTrips.Application.Mappings
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {
            CreateMap<TripDto, Trip>().ForMember(p => p.User, opt => opt.MapFrom(src => new User()
            {
                Name = src.UserName,
                Email = src.Email
            }));

            CreateMap<Trip,TripDto>();

        }
    }
}
