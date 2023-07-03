using AlpTrips.Application.ApplicationUser;
using AlpTrips.Application.Dtos;
using AlpTrips.Application.Event;
using AlpTrips.Domain.Entities;
using AlpTrips.Domain.Interfaces;
using AlpTrips.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlpTrips.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private AlpTripsDbContext _context;
        private IUserContext _userContext;
        public UserRepository(AlpTripsDbContext context, IUserContext userContext)
        {
            _context = context;
            _userContext = userContext;

        }
        public async Task<string> GetUserNameById(string userId)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);

            if (user != null)
            {
                return user.Name;
            }

            return null;
        }

        public async Task<IEnumerable<Trip>> UserTrips(string userId)
        {
            var userTrips = await _context.Trips.Include(t => t.Gallery).Where(t => t.CreatedById == userId).ToListAsync();
            return userTrips;
        }

        public async Task AddToFavourite(Trip trip)
        {
            var currentUser = _userContext.GetCurrentUser();
            var user = _context.Users.Include(u => u.FavouriteTripsList).Where(u => u.Id == currentUser.Id).FirstOrDefault();
            user.FavouriteTripsList.Add(trip);
            await _context.SaveChangesAsync();

        }

        public async Task<IEnumerable<Trip>> UserFavouriteTrips(string userId)
        {
            var user = await _context.Users.Include(u => u.FavouriteTripsList).FirstOrDefaultAsync(u => u.Id == userId);

            var favouriteTrips = user.FavouriteTripsList.ToList();
            return favouriteTrips;

        }


        public async Task AddEvent(Event eventt)
        {
            var currentUser = _userContext.GetCurrentUser();
            var user = _context.Users.Include(u => u.Events).Where(u => u.Id == currentUser.Id).FirstOrDefault();
            var trip = _context.Trips.Where(t => t.Name == eventt.Destination).FirstOrDefault();
            eventt.Trip = trip;
            eventt.TripId = trip.Id;
            User userr = User.FromCurrentUser(currentUser);
            eventt.User = userr;
            eventt.UserId = userr.Id;

            if (EventDateValidator.ValidateOverlapping(user.Events, eventt))
            {
                user.Events.Add(eventt);
            }
            else
            {
                throw new Exception("This date is already booked");
            }

            await _context.SaveChangesAsync();

        }

        public async Task<IEnumerable<Event>> UserEvents(string userId)
        {
            var user = await _context.Users.Include(u => u.Events).FirstOrDefaultAsync(u => u.Id == userId);

            var events = user.Events.ToList();
            return events;

        }







    }
}
