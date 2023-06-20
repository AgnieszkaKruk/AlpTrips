using AlpTrips.Application.Dtos;
using AlpTrips.Domain.Entities;
using AlpTrips.Domain.Interfaces;
using AlpTrips.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
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
        public UserRepository(AlpTripsDbContext context)
        {
            _context = context;

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
            var userTrips = await  _context.Trips.Include(t=>t.Gallery).Where(t=>t.UserId == userId).ToListAsync();
            return userTrips;
        }

    }
}
