using AlpTrips.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlpTrips.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<string> GetUserNameById(string userId);
        Task<IEnumerable<Trip>> UserTrips(string userId);
        Task AddToFavourite(Trip trip);
        Task<IEnumerable<Trip>> UserFavouriteTrips(string userId);

        Task AddEvent(Event eventt);
        Task<IEnumerable<Event>> UserEvents(string userId);
    }
}
