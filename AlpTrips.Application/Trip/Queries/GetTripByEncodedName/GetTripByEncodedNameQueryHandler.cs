using AlpTrips.Application.Dtos;
using AlpTrips.Domain.Interfaces;
using AutoMapper;
using MediatR;

namespace AlpTrips.Application.Trip.Queries.GetTripByEncodedName
{
    public class GetTripByEncodedNameQueryHandler : IRequestHandler<GetTripByEncodedNameQuery, TripDto>
    {
        private readonly ITripRepository _tripRepository;
        private readonly IMapper _mapper;

        public GetTripByEncodedNameQueryHandler(ITripRepository tripRepository, IMapper mapper)
        {
            _tripRepository = tripRepository;
            _mapper = mapper;
        }


        public async Task<TripDto> Handle(GetTripByEncodedNameQuery request, CancellationToken cancellationToken)
        {
           var trip = await _tripRepository.GetByEncodedName(request.EncodedName);
            var tripDto = _mapper.Map<TripDto>(trip);
            return tripDto;
            
        }
    }
}
