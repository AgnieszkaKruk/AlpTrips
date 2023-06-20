using AlpTrips.Application.Dtos;
using AlpTrips.Domain.Interfaces;
using AutoMapper;
using MediatR;

namespace AlpTrips.Application.Trip.Queries.FindBestWeather
{
    public class FindBestWeatherNextWeekQueryHandler : IRequestHandler<FindBestWeatherNextWeekQuery, TripDto>
    {
        private readonly ITripRepository _tripRepository;
        private readonly IMapper _mapper;
        public FindBestWeatherNextWeekQueryHandler(ITripRepository tripRepository, IMapper mapper)
        {
            _tripRepository = tripRepository;
            _mapper = mapper;

        }
        public async Task<TripDto> Handle(FindBestWeatherNextWeekQuery request, CancellationToken cancellationToken)
        {
            var trip = await _tripRepository.FindBestWeatherNextWeek();
            var tripDto = _mapper.Map<TripDto>(trip);
            return tripDto;
        }
    }
    
}
