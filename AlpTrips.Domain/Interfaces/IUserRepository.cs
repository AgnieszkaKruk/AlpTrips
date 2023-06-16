using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlpTrips.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<string> GetUserNameById(string userId);
    }
}
