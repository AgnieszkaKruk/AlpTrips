using AlpTrips.Domain.Interfaces;
using MediatR;

namespace AlpTrips.Application.Trip.Queries.GetTripByEncodedName
{
    public class GetTripByEncodedNameQueryHandler : IRequestHandler<GetTripByEncodedNameQuery,Domain.Entities.Trip>
    {
        private readonly ITripRepository _tripRepository;
       

        public GetTripByEncodedNameQueryHandler(ITripRepository tripRepository)
        {
            _tripRepository = tripRepository;
           
        }


        public async Task<Domain.Entities.Trip> Handle(GetTripByEncodedNameQuery request, CancellationToken cancellationToken)
        {
           var trip = await _tripRepository.GetByEncodedName(request.EncodedName);
    
            return trip;
            
        }

    }
}
