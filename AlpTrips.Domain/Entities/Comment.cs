using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public IdentityUser? CreatedBy { get; set; }

    }
}
