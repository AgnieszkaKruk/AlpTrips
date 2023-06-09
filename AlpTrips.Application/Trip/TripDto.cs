﻿using Microsoft.AspNetCore.Http;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace AlpTrips.Application.Dtos
{
    public class TripDto
    {
        public TripDto()
        {
            
        }

        public string Name { get; set; }
        public string? Description { get; set; }
        public int? Height { get; set; }
   
        public string MountainRange { get; set; }
        public string? MountainSubRange { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public int Length { get; set; }
       
        public int Elevation { get; set; }
       
        public int Time { get; set; }
       
        public int Level { get; set; }
        
        public string? Link { get; set; }
       
        public IFormFile ImageFile { get; set; }
        public string ImageUrl { get; set; }
        public string UserName { get; set; } 
      
        public string Email { get; set; }
        public string? EncodedName { get; set; }

        public List<Domain.Entities.Comment>? Comments { get; set; } = new List<Domain.Entities.Comment>();

        public IFormFileCollection GalleryFiles { get; set; }
        public List<GalleryDto> Gallery { get; set; }
    }
}
