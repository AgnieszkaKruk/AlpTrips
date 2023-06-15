using AlpTrips.Domain.Entities;


namespace AlpTrips.Domain.Interfaces
{
    public interface  ITripRepository

    {
        Task Create(Trip trip);
        Task <Trip?> GetByName(string name);
        Task<Trip> GetByEncodedName(string encodedName);
        Task<IEnumerable<Trip>> GetAll();
        Task Delete(string encodedName);
        Task Savechanges();
        Task<IEnumerable<Trip>> GetTop6Trips();
        Task<IEnumerable<Trip>> SearchTrip(string search);
        Task<IEnumerable<Trip>> SearchTripByParams(int? level, string? length, string? elevation, string? time);
    }
}
