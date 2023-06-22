using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlpTrips.Domain.Entities
{
    public class FavouriteTrip
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        
    }
}
