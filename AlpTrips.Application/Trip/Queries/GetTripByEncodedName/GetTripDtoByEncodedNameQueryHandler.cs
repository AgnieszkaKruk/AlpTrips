using AlpTrips.Application.ApplicationUser;
using AlpTrips.Application.Dtos;
using AlpTrips.Domain.Interfaces;
using AutoMapper;
using MediatR;

namespace AlpTrips.Application.Trip.Queries.GetTripByEncodedName
{
    public class GetTripDtoByEncodedNameQueryHandler : IRequestHandler<GetTripDtoByEncodedNameQuery, TripDto>
    {
        private readonly ITripRepository _tripRepository;
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public GetTripDtoByEncodedNameQueryHandler(IUserRepository userRepository, ITripRepository tripRepository, IMapper mapper)
        {
            _tripRepository = tripRepository;
            _mapper = mapper;         
            _userRepository = userRepository;
        }


        public async Task<TripDto> Handle(GetTripDtoByEncodedNameQuery request, CancellationToken cancellationToken)
        {
            var trip = await _tripRepository.GetByEncodedName(request.EncodedName);

            var userName = await _userRepository.GetUserNameById(trip.UserId);

            var tripDto = _mapper.Map<TripDto>(trip);
            tripDto.UserName = userName;

            return tripDto;
        }


    }
}
