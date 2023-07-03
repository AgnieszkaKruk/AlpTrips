using AlpTrips.Application.ApplicationUser;
using AlpTrips.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlpTrips.Application.User.Queries.UserEvents
{
    public class UserEventsQueryHandler : IRequestHandler<UserEventsQuery, IEnumerable<Domain.Entities.Event>>
    {
        private IUserRepository _userRepository;
        private readonly IUserContext _userContext;
        public UserEventsQueryHandler(IUserRepository userRepository, IUserContext userContext)
        {
            _userRepository = userRepository;
            _userContext = userContext;
        }
        public Task<IEnumerable<Domain.Entities.Event>> Handle(UserEventsQuery request, CancellationToken cancellationToken)
        {
            var userId = _userContext.GetCurrentUser().Id;
            var userEvents = _userRepository.UserEvents(userId);
            return userEvents;
        }
    }
}
