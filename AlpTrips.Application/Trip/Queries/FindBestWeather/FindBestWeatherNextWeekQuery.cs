using AlpTrips.Application.Dtos;
using MediatR;

namespace AlpTrips.Application.Trip.Queries.FindBestWeather
{
    public class FindBestWeatherNextWeekQuery : IRequest<TripDto>
    {
    }
}
