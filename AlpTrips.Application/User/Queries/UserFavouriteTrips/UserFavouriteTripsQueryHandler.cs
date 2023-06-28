using AlpTrips.Application.ApplicationUser;
using AlpTrips.Application.Dtos;
using AlpTrips.Domain.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlpTrips.Application.User.Queries.UserFavouriteTrips
{
    public class UserFavouriteTripsQueryHandler : IRequestHandler<UserFavouriteTripsQuery, IEnumerable<TripDto>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IUserContext _userContext;
        public UserFavouriteTripsQueryHandler(IUserRepository userRepository, IMapper mapper, IUserContext userContext)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _userContext = userContext;

        }
        public async Task<IEnumerable<TripDto>> Handle(UserFavouriteTripsQuery request, CancellationToken cancellationToken)
        {
            var userId = _userContext.GetCurrentUser().Id;
            var userTrips = await _userRepository.UserFavouriteTrips(userId);
            var userTripsDto = _mapper.Map<IEnumerable<TripDto>>(userTrips);
            return userTripsDto;
        }
    }
}


