using AlpTrips.Application.Dtos;
using AlpTrips.Domain.Entities;
using AlpTrips.Domain.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Http;


namespace AlpTrips.Application.Services
{
    public class TripService : ITripService
    {
        private readonly ITripRepository _tripRepository;
        private readonly IMapper _mapper;
        public TripService(ITripRepository tripRepository, IMapper mapper)
        {
            _tripRepository = tripRepository;
            _mapper = mapper;
        }

        public async Task Create(TripDto tripDto)
        {
            var trip =  _mapper.Map<Trip>(tripDto);
            trip.SetEncodedName();
          //  trip.Image = tripDto.Image;

            await _tripRepository.Create(trip);
        }

      
     
    }
}