

using MediatR;

namespace AlpTrips.Application.Trip.Queries.GetTripByEncodedName
{
    public class GetTripByEncodedNameQuery : IRequest<Domain.Entities.Trip>
    {
        public string EncodedName { get; set; }
        public GetTripByEncodedNameQuery(string encodedName)
        {
            EncodedName = encodedName;
        }
    }
}
