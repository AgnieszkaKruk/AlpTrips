using AlpTrips.Application.Dtos;
using MediatR;

namespace AlpTrips.Application.User.Queries
{
    public class UserFavouriteTripsQuery: IRequest<IEnumerable<TripDto>>
    {
    }
}
