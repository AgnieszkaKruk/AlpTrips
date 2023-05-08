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

        public GetTripDtoByEncodedNameQueryHandler(ITripRepository tripRepository, IMapper mapper)
        {
            _tripRepository = tripRepository;
            _mapper = mapper;
        }


        public async Task<TripDto> Handle(GetTripDtoByEncodedNameQuery request, CancellationToken cancellationToken)
        {
           var trip = await _tripRepository.GetByEncodedName(request.EncodedName);
            var tripDto = _mapper.Map<TripDto>(trip);
            return tripDto;
            
        }

    }
}
