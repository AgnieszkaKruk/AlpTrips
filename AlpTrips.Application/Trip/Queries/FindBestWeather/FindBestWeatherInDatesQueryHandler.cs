using AlpTrips.Application.Dtos;
using AlpTrips.Domain.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlpTrips.Application.Trip.Queries.FindBestWeather
{
    public class FindBestWeatherInDatesQueryHandler : IRequestHandler<FindBestWeatherInDatesQuery, TripDto>
    {
        private readonly ITripRepository _tripRepository;
        private readonly IMapper _mapper;
        public FindBestWeatherInDatesQueryHandler(ITripRepository tripRepository, IMapper mapper)
        {
            _tripRepository = tripRepository;
            _mapper = mapper;

        }
        public async Task<TripDto> Handle(FindBestWeatherInDatesQuery request, CancellationToken cancellationToken)
        {
            var trip = await _tripRepository.FindBestWeatherInDates(request.Start,request.End);
            var tripDto = _mapper.Map<TripDto>(trip);
            return tripDto;
        }
    }
}
