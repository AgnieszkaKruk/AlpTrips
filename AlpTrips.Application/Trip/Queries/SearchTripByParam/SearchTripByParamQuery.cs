using AlpTrips.Application.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlpTrips.Application.Trip.Queries.SearchTripByParam
{
    public class SearchTripByParamQuery: IRequest<IEnumerable<TripDto>>
    {
        public int? Level { get; set; }
        public string? Length { get; set; }
        public string? Elevation { get; set; }
        public string? Time { get; set; }

        public SearchTripByParamQuery(int? level, string? length, string? elevation, string? time)
        {
            Level = level;
            Length = length;
            Elevation = elevation;
            Time = time;
        }
    }
}
