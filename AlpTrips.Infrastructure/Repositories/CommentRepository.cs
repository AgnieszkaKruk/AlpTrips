using AlpTrips.Domain.Entities;
using AlpTrips.Domain.Interfaces;
using AlpTrips.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlpTrips.Infrastructure.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private AlpTripsDbContext _context;
        public CommentRepository(AlpTripsDbContext context)
        {
            _context = context;
        }

        public async Task Create(Comment comment)
        {
            try
            {
                _context.Comments.Add(comment);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task<IEnumerable<Comment>> GetAll()
        => await _context.Comments.ToListAsync();


        public async Task<IEnumerable<Comment>> GetByEncodedName(string encodedName)
        {
            var trip = await _context.Trips.FirstOrDefaultAsync(t => t.EncodedName == encodedName);
            var comments =  await _context.Comments.Where(c => c.TripId == trip.Id).ToListAsync();
            return comments;
        }
           
            
    }
}
