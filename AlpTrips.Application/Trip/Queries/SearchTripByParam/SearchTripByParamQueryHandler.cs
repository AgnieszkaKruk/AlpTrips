using AlpTrips.Application.Dtos;
using AlpTrips.Domain.Interfaces;
using AutoMapper;
using MediatR;

namespace AlpTrips.Application.Trip.Queries.SearchTripByParam
{
    public class SearchTripByParamQueryHandler : IRequestHandler<SearchTripByParamQuery, IEnumerable<TripDto>>
    {
        private readonly ITripRepository _tripRepository;
        private readonly IMapper _mapper;

        public SearchTripByParamQueryHandler(ITripRepository tripRepository, IMapper mapper)
        {
            _mapper = mapper;
            _tripRepository = tripRepository;
        }
        public async Task<IEnumerable<TripDto>> Handle(SearchTripByParamQuery request, CancellationToken cancellationToken)
        {
            var trips = await _tripRepository.SearchTripByParams(request.Level,request.Length, request.Elevation,request.Time);
            var tripsDto = _mapper.Map<IEnumerable<TripDto>>(trips);
            return tripsDto;
        }
    }
}
