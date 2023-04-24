using AlpTrips.Domain.Interfaces;
using MediatR;

namespace AlpTrips.Application.Trip.Commands.DeleteTrip
{
    public class DeleteTripHandler : IRequestHandler<DeleteTripCommand>
    {
        private readonly ITripRepository _tripRepository;
        public DeleteTripHandler(ITripRepository tripRepository)
        {
            _tripRepository = tripRepository;  
        }
        public async Task<Unit> Handle(DeleteTripCommand request, CancellationToken cancellationToken)
        {
            var trip = await  _tripRepository.GetByEncodedName(request.EncodedName);
            await  _tripRepository.Delete(request.EncodedName);
            
            return Unit.Value;

        }
    }
}
