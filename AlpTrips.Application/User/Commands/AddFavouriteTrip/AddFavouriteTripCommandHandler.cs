using AlpTrips.Application.ApplicationUser;
using AlpTrips.Domain.Entities;
using AlpTrips.Domain.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlpTrips.Application.User.Commands.AddFavouriteTrip
{
    public class AddFavouriteTripCommandHandler : IRequestHandler<AddFavouriteTripCommand>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly ITripRepository _tripRepository;


        public AddFavouriteTripCommandHandler(ITripRepository tripRepository, IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _tripRepository = tripRepository;
        }

        public async Task<Unit> Handle(AddFavouriteTripCommand request, CancellationToken cancellationToken)
        {
            var trip = await _tripRepository.GetByEncodedName(request.EncodedName);
            await _userRepository.AddToFavourite(trip);

            return Unit.Value;
        }

    }
}
