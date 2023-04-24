
using AlpTrips.Application.Dtos;
using MediatR;

namespace AlpTrips.Application.Trip.Queries.GetTripByEncodedName
{
    public class GetTripByEncodedNameQuery : IRequest<TripDto>
    {
        public string EncodedName { get; set; }
        public GetTripByEncodedNameQuery(string encodedName)
        {
            EncodedName = encodedName;
        }
    }
}
