using AlpTrips.Application.Dtos;
using MediatR;

namespace AlpTrips.Application.Trip.Commands.CreateTrip
{
    public class CreateTripCommand: TripDto, IRequest
    {
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public CreateTripCommand(string latitude, string longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }
        public CreateTripCommand()
        {
            
        }

    }
}
