using AlpTrips.Application.Dtos;
using MediatR;

namespace AlpTrips.Application.Trip.Queries.SearchTripQuery
{
    public class SearchTripQuery: IRequest<IEnumerable<TripDto>>
    {
        public string Search { get; set; }
        public SearchTripQuery(string search) 
        { 
            Search = search;
        }
        public SearchTripQuery()
        {
            
        }
    }
}
