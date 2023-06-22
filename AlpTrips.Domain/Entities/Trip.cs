using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;


namespace AlpTrips.Domain.Entities
{
    public class Trip
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string MountainRange { get; set; }
        public string? MountainSubRange { get; set; }
        public int? Height { get; set; }

        public int Length { get; set; }
        public int Elevation { get; set; }
        public int Time { get; set; }
        public int Level { get; set; }
        public string? Link { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public User User { get; set; }
        [NotMapped]
        public User? FavouriteUser { get; set; }
        public string? FavouriteUserId { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string UserId { get; set; }
        public string? EncodedName { get; set; }
       
        public string? CreatedById { get; set; }
        public User? CreatedBy { get; set; }
        public string? ImageUrl { get; set; }
        public List<Comment>? Comments { get; set; } = new List<Comment>();

        public void SetEncodedName() => EncodedName = Name.ToLower().Replace(" ","-");

        public ICollection<TripGallery> Gallery { get; set; }

    }
}