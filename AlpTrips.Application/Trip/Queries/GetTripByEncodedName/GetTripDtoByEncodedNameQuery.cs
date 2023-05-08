
using AlpTrips.Application.Dtos;
using MediatR;

namespace AlpTrips.Application.Trip.Queries.GetTripByEncodedName
{
    public class GetTripDtoByEncodedNameQuery : IRequest<TripDto>
    {
        public string EncodedName { get; set; }
        public GetTripDtoByEncodedNameQuery(string encodedName)
        {
            EncodedName = encodedName;
        }
    }
}
