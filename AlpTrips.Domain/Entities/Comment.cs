using Microsoft.AspNetCore.Identity;
namespace AlpTrips.Domain.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int Rate { get; set; }
        public DateTime CreatedDate { get; set; }
        public int TripId { get; set; }

        public string? CreatedById { get; set; }
        public User User  { get; set; }
        public int UserId { get; set; }
        public Trip Trip { get; set; }

    }
}
