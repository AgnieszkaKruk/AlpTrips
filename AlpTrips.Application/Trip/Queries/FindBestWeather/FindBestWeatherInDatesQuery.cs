using AlpTrips.Application.Dtos;
using MediatR;

namespace AlpTrips.Application.Trip.Queries.FindBestWeather
{
 
    public class FindBestWeatherInDatesQuery:IRequest<TripDto>
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public FindBestWeatherInDatesQuery(DateTime start, DateTime end)
        {
            Start = start;
            End = end;
                
        }
    }
}
