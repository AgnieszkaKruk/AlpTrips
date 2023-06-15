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

        public async Task<IEnumerable<Trip>> GetAll()
         => await _context.Trips.ToListAsync();

        public async Task<IEnumerable<Trip>> GetTop6Trips()
        => await _context.Trips.Take(6).ToListAsync();

        public async Task<Trip?> GetByName(string name)
          => await _context.Trips.FirstOrDefaultAsync(t => t.Name.ToLower() == name.ToLower());

        public async Task<Trip> GetByEncodedName(string encodedName)
            => await _context.Trips.Include(t => t.User).Include(t => t.Gallery).FirstOrDefaultAsync(t => t.EncodedName == encodedName);

        public async Task Savechanges()
         => await _context.SaveChangesAsync();

        public async Task Delete(string encodedName)
        {
            var trip = await _context.Trips.FirstOrDefaultAsync(t => t.EncodedName == encodedName);
            _context.Trips.Remove(trip);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Trip>> SearchTrip(string search)
        {
            var searchingTrips = await _context.Trips.Where(t => t.Name.Contains(search))
                .Include(t => t.Gallery).ToListAsync();
            return searchingTrips;
        }

        public async Task<IEnumerable<Trip>> SearchTripByParams(int? level, string? length, string? elevation, string? time)
        {
            var searchingTrips = await _context.Trips
                .Include(t => t.Gallery)
                .ToListAsync();
            if (level.HasValue)
            {
                searchingTrips = searchingTrips.Where(t => t.Level == level).ToList();
            }
            
                if (!string.IsNullOrEmpty(length))
                {
                    switch (length)
                    {
                        case "0-10":
                            searchingTrips = searchingTrips.Where(t => t.Length <= 10).ToList();
                            break;
                        case "11-15":
                            searchingTrips = searchingTrips.Where(t => t.Length >= 11 && t.Length <= 15).ToList();
                            break;
                        case "16-20":
                            searchingTrips = searchingTrips.Where(t => t.Length >= 16 && t.Length <= 20).ToList();
                            break;
                        case "21-25":
                            searchingTrips = searchingTrips.Where(t => t.Length >= 21 && t.Length <= 25).ToList();
                            break;
                        case ">25":
                            searchingTrips = searchingTrips.Where(t => t.Length > 25).ToList();
                            break;
                    }
                }

                // Filtrowanie przewyższenia
                if (!string.IsNullOrEmpty(elevation))
                {
                    switch (elevation)
                    {
                        case "0-1000":
                            searchingTrips = searchingTrips.Where(t => t.Elevation <= 1000).ToList();
                            break;
                        case "1001-1500":
                            searchingTrips = searchingTrips.Where(t => t.Elevation >= 1001 && t.Elevation <= 1500).ToList();
                            break;
                        case "1501-2000":
                            searchingTrips = searchingTrips.Where(t => t.Elevation >= 1501 && t.Elevation <= 2000).ToList();
                            break;
                        case "2001-2500":
                            searchingTrips = searchingTrips.Where(t => t.Elevation >= 2001 && t.Elevation <= 2500).ToList();
                            break;
                        case ">2500":
                            searchingTrips = searchingTrips.Where(t => t.Elevation > 2500).ToList();
                            break;
                    }
                }

                // Filtrowanie czasu przejścia
                if (!string.IsNullOrEmpty(time))
                {
                    switch (time)
                    {
                        case "0-5":
                            searchingTrips = searchingTrips.Where(t => t.Time <= 5).ToList();
                            break;
                        case "6-10":
                            searchingTrips = searchingTrips.Where(t => t.Time >= 6 && t.Time <= 10).ToList();
                            break;
                        case "11-15":
                            searchingTrips = searchingTrips.Where(t => t.Time >= 11 && t.Time <= 15).ToList();
                            break;
                        case "16-20":
                            searchingTrips = searchingTrips.Where(t => t.Time >= 16 && t.Time <= 20).ToList();
                            break;
                        case ">20":
                            searchingTrips = searchingTrips.Where(t => t.Time > 20).ToList();
                            break;
                    }
                }
            


            return searchingTrips;
        }




    }
}