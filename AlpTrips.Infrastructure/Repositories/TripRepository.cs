using AlpTrips.Domain.Entities;
using AlpTrips.Domain.Interfaces;
using AlpTrips.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace AlpTrips.Infrastructure.Repositories
{
    public class TripRepository : ITripRepository
    {
        private AlpTripsDbContext _context;
        public TripRepository(AlpTripsDbContext _dbContext)
        {
            _context = _dbContext;

        }
        public async Task Create(Trip trip)
        {
            try
            {
                _context.Trips.Add(trip);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public Task<Trip?> GetByName(string name)

          => _context.Trips.FirstOrDefaultAsync(t => t.Name.ToLower() == name.ToLower());
        
    }
}