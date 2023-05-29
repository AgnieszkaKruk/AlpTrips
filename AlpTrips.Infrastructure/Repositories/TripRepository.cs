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

        public async  Task<IEnumerable<Trip>> GetAll()
         =>  await _context.Trips.ToListAsync();

        public async Task<IEnumerable<Trip>> GetTop6Trips()
        => await _context.Trips.Take(6).ToListAsync();

        public async Task<Trip?> GetByName(string name)
          => await _context.Trips.FirstOrDefaultAsync(t => t.Name.ToLower() == name.ToLower());

        public async Task<Trip> GetByEncodedName(string encodedName)
            => await _context.Trips.Include(t => t.User).Include(t=>t.Gallery).FirstOrDefaultAsync(t=> t.EncodedName == encodedName);

        public async Task Savechanges()
         => await _context.SaveChangesAsync();

        public async Task Delete(string encodedName)
        {
             var trip = await _context.Trips.FirstOrDefaultAsync(t =>t.EncodedName == encodedName);
             _context.Trips.Remove(trip);
            await _context.SaveChangesAsync();
        }
    }
}