using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlpTrips.Application.Event
{

    public static class EventDateValidator
    {


        public static bool ValidateOverlapping(List<Domain.Entities.Event> events, Domain.Entities.Event newEvent)
        {
            if (events == null || !events.Any()) return true;


            var overlappingEvents = events
                .FirstOrDefault(ev => newEvent.Start.Date >= ev.Start.Date && newEvent.Start.Date <= ev.End.Date
                                    || newEvent.End.Date >= ev.End.Date && newEvent.End.Date <= ev.End.Date);

            if (overlappingEvents != null) return false;


            var outerOverlappingDateEvents = events
                .FirstOrDefault(ev => ev.Start.Date <= newEvent.Start.Date && ev.End.Date >= newEvent.End.Date);

            if (outerOverlappingDateEvents != null) return false;


            var innerOverlappingDateEvents = events
                .FirstOrDefault(ev => ev.Start.Date <= newEvent.End.Date && ev.Start.Date >= newEvent.End.Date
                 && ev.Start.Date <= newEvent.End.Date && ev.End.Date >= newEvent.Start.Date);


            if (innerOverlappingDateEvents != null) return false;

            return true;
        }
    }
}


