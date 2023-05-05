using AlpTrips.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlpTrips.Domain.Interfaces
{
    public interface ICommentRepository
    {
        Task Create(Comment comment);
        Task<IEnumerable<Comment>> GetAll();
        Task<IEnumerable<Comment>> GetByEncodedName(string encodedName);
    }
}
