using AlpTrips.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlpTrips.Domain.Interfaces
{
    public interface  ITripRepository

    {
        Task Create(Trip trip);
        Task <Trip?> GetByName(string name);
    }
}
