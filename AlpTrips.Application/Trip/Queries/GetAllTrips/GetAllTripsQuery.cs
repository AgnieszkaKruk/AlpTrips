using AlpTrips.Application.Dtos;
using MediatR;

namespace AlpTrips.Application.Trip.Queries.GetAllTrips
{
    public class GetAllTripsQuery : IRequest<IEnumerable<TripDto>>
    {
    }
}
