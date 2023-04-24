using AlpTrips.Application.Dtos;
using MediatR;

namespace AlpTrips.Application.Trip.Commands.CreateTrip
{
    public class CreateTripCommand: TripDto, IRequest
    {

    }
}
