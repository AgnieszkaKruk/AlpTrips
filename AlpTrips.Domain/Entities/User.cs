using Microsoft.AspNetCore.Identity;

namespace AlpTrips.Domain.Entities
{
    public class User :IdentityUser
    {
        public string Name { get; set; }
        public List<Trip> TripsList { get;  set;} = new List<Trip>();
        public List<Comment> CommentsList { get; set; } = new List<Comment>();
        
    }
}
