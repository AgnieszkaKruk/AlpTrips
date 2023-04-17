﻿using Microsoft.AspNetCore.Http;
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

        public int Length { get; set; }
        public int Elevation { get; set; }
        public int Time { get; set; }
        public int Level { get; set; }
        public string? Link { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public User User { get; set; } 
        public int UserId { get; set; }
        public string? EncodedName { get; set; }
       

        public string? ImageUrl { get; set; }

        public void SetEncodedName() => EncodedName = Name.ToLower().Replace(" ","-");
    }
}