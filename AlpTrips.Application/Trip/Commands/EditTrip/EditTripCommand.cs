using AlpTrips.Application.Dtos;
using MediatR;

namespace AlpTrips.Application.Trip.Commands.EditTrip
{
    public class EditTripCommand : TripDto, IRequest
    {
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public EditTripCommand(string latitude, string longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }
        public EditTripCommand()
        {
            
        }
    }
}
