namespace AlpTrips.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get;  set; }
        public string Email { get;  set; }
        public List<Trip> TripsList { get;  set;} = new List<Trip>();
        public List<Comment> CommentsList { get; set; } = new List<Comment>();
        
    }
}
