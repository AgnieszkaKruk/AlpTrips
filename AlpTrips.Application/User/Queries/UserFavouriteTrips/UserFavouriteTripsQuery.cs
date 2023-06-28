using AlpTrips.Application.Dtos;
using MediatR;

namespace AlpTrips.Application.User.Queries.UserFavouriteTrips
{
    public class UserFavouriteTripsQuery : IRequest<IEnumerable<TripDto>>
    {
    }
}
