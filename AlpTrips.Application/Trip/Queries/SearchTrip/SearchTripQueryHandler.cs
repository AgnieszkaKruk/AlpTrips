using AlpTrips.Application.Dtos;
using AlpTrips.Domain.Interfaces;
using AutoMapper;
using MediatR;

namespace AlpTrips.Application.Trip.Queries.SearchTripQuery
{
    public class SearchTripQueryHandler : IRequestHandler<SearchTripQuery,IEnumerable<TripDto>>
    {
        private readonly ITripRepository _tripRepository;
        private readonly IMapper _mapper;

        public SearchTripQueryHandler(ITripRepository tripRepository, IMapper mapper)
        {
            _tripRepository = tripRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<TripDto>> Handle(SearchTripQuery request, CancellationToken cancellationToken)
        {
            var trips = await _tripRepository.SearchTrip(request.Search);
            var tripsDto = _mapper.Map<IEnumerable<TripDto>>(trips);
            return tripsDto;
        }

       
    }
}
