using AlpTrips.Application.ApplicationUser;
using AlpTrips.Application.Dtos;
using AlpTrips.Domain.Entities;
using AlpTrips.Domain.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlpTrips.Application.User.Queries
{
    public class UserTripsQueryHandler : IRequestHandler<UserTripsQuery, IEnumerable<TripDto>>

    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IUserContext _userContext;
        public UserTripsQueryHandler(IUserRepository userRepository, IMapper mapper, IUserContext userContext)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _userContext = userContext;
        }
        public async Task<IEnumerable<TripDto>> Handle(UserTripsQuery request, CancellationToken cancellationToken)
        {
            var userId = _userContext.GetCurrentUser().Id;
            var userTrips = await _userRepository.UserTrips(userId);
            var userTripsDto = _mapper.Map<IEnumerable<TripDto>>(userTrips);
            return userTripsDto;
        }
    }
}
