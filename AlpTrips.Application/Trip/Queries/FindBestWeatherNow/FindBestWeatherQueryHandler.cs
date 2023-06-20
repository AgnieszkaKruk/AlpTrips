using AlpTrips.Application.Dtos;
using AlpTrips.Application.Trip.Queries.GetTripByEncodedName;
using AlpTrips.Domain.Interfaces;
using AutoMapper;
using MediatR;

namespace AlpTrips.Application.Trip.Queries.FindBestWeather
{
    public class FindBestWeatherQueryHandler : IRequestHandler<FindBestWeatherNowQuery, TripDto>
    {
        private readonly ITripRepository _tripRepository;
        private readonly IMapper _mapper;
        public FindBestWeatherQueryHandler(ITripRepository tripRepository, IMapper mapper)
        {
            _tripRepository = tripRepository;
            _mapper = mapper;

        }
        public async Task<TripDto> Handle(FindBestWeatherNowQuery request, CancellationToken cancellationToken)
        {
            var trip = await _tripRepository.FindBestWeatherNow();
            var tripDto = _mapper.Map<TripDto>(trip);
            return tripDto;
        }
    }
}
