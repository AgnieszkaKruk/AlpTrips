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

            return null; // lub inna wartość domyślna, jeśli użytkownik o danym ID nie został znaleziony
        }


    }
}
