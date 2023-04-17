using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlpTrips.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get;  set; }
        public string Email { get;  set; }
        public List<Trip> TripsList { get; private set;} = new List<Trip>();
        
    }
}
