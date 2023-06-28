using AlpTrips.Application.User.Commands.AddFavouriteTrip;
using AlpTrips.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlpTrips.Application.User.Commands.AddEvent
{
    public class AddEventCommandHandler : IRequestHandler<AddEventCommand>
    {
        private readonly IUserRepository _userRepository;
        public AddEventCommandHandler(IUserRepository user)
        {
            _userRepository = user;
        }

        public async  Task<Unit> Handle(AddEventCommand request, CancellationToken cancellationToken)
        {

             await _userRepository.AddEvent(request);
            return Unit.Value;
        }
    }
}
