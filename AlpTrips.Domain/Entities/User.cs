using AlpTrips.Application.ApplicationUser;
using Microsoft.AspNetCore.Identity;


namespace AlpTrips.Domain.Entities
{
    public class User :IdentityUser
    {
        public string Name { get; set; }
        public ICollection<Trip>? FavouriteTripsList { get; set; } = new List<Trip>();
        public List<Comment> CommentsList { get; set; } = new List<Comment>();


        public List<Event> Events { get; set; } = new List<Event>();

        public static User FromCurrentUser(CurrentUser currentUser)
        {
            var user = new User
            {
                Id = currentUser.Id,
                Name = currentUser.Name,
                // Przypisz inne właściwości, jeśli istnieją
            };

            return user;
        }
    }
}
