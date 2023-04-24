using AlpTrips.Application.Dtos;
using AlpTrips.Domain.Interfaces;
using AutoMapper;
using MediatR;

namespace AlpTrips.Application.Trip.Queries.GetAllTrips
{
    public class GetAllTripsQueryHandler : IRequestHandler<GetAllTripsQuery, IEnumerable<TripDto>>
    {
        private readonly ITripRepository _tripRepository;
        private readonly IMapper _mapper;

        public GetAllTripsQueryHandler(ITripRepository tripRepository, IMapper mapper)
        {
            _tripRepository = tripRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<TripDto>> Handle(GetAllTripsQuery request, CancellationToken cancellationToken)
        {
            var allTrips = await _tripRepository.GetAll();
            var tripsDto = _mapper.Map<IEnumerable<TripDto>>(allTrips);
            return tripsDto;

        }
    }
}
