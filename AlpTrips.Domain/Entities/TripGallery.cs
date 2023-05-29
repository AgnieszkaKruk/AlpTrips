namespace AlpTrips.Domain.Entities
{
    public class TripGallery
    {
        public int Id { get; set; }
        public int TripId { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }

        public Trip Trip { get; set; }

    }
}
