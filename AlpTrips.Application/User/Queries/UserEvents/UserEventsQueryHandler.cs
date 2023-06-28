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
        public Task<IEnumerable<Domain.Entities.Event>> Handle(UserEventsQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
