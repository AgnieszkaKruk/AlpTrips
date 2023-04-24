using AlpTrips.Domain.Interfaces;
using AutoMapper;
using MediatR;

namespace AlpTrips.Application.Trip.Commands.EditTrip
{
    public class EditTripCommandHandler : IRequestHandler<EditTripCommand>
    {
        private readonly ITripRepository _tripRepository;
        private readonly IMapper _mapper;

        public EditTripCommandHandler(ITripRepository tripRepository, IMapper mapper)
        {
            _tripRepository = tripRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(EditTripCommand request, CancellationToken cancellationToken)
        {
            var trip = await _tripRepository.GetByEncodedName(request.EncodedName);
            trip.Description = request.Description;
            trip.Elevation = request.Elevation;
            trip.Length = request.Length;
            trip.Time = request.Time;
            trip.Level = request.Level;
            trip.CreatedDate = DateTime.Now;
            trip.ImageUrl = request.ImageUrl;
            trip.Link = request.Link;
            trip.MountainRange = request.MountainRange;
           

            await _tripRepository.Savechanges();

            return Unit.Value;
        }
    }
}
