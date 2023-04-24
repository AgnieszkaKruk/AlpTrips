using AlpTrips.Application.Dtos;
using MediatR;

namespace AlpTrips.Application.Trip.Commands.EditTrip
{
    public class EditTripCommand : TripDto, IRequest
    {
    }
}
