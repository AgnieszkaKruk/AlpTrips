using AlpTrips.Application.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlpTrips.Application.User.Queries.UserTrips
{
    public class UserTripsQuery : IRequest<IEnumerable<TripDto>>
    {

    }
}
