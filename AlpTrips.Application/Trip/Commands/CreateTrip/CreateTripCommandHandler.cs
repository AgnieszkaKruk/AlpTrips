using AlpTrips.Application.ApplicationUser;
using AlpTrips.Domain.Interfaces;
using AutoMapper;
using MediatR;

namespace AlpTrips.Application.Trip.Commands.CreateTrip
{
    public class CreateTripCommandHandler : IRequestHandler<CreateTripCommand>
    {
        private readonly ITripRepository _tripRepository;
        private readonly IMapper _mapper;
        private readonly IUserContext _userContext;

        public CreateTripCommandHandler(ITripRepository tripRepository, IMapper mapper, IUserContext userContext)
        {
            _tripRepository = tripRepository;
            _mapper = mapper;
            _userContext = userContext;
        }
        public async Task<Unit> Handle(CreateTripCommand request, CancellationToken cancellationToken)
        {
            var trip = _mapper.Map<Domain.Entities.Trip>(request);
            trip.SetEncodedName();
          

            trip.CreatedById = _userContext.GetCurrentUser().Id;
            trip.User.Email = _userContext.GetCurrentUser().Email;
            trip.User.Name = _userContext.GetCurrentUser().Name;
            trip.UserId = trip.CreatedById;
            trip.Latitude = request.Latitude;
            trip.Longitude= request.Longitude;
            trip.MountainSubRange = request.MountainSubRange;

            await _tripRepository.Create(trip);
            
            return Unit.Value;
        }
    }
}
