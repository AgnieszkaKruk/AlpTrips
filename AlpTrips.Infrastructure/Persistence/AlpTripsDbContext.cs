using AlpTrips.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AlpTrips.Infrastructure.Persistence
{
    public class AlpTripsDbContext : IdentityDbContext<User>
    {
        public AlpTripsDbContext(DbContextOptions<AlpTripsDbContext> options) : base(options)
        {

        }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Trip> Trips { get; set; }
        public DbSet<TripGallery> Galleries { get; set; }
        public DbSet<Event> Events { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Trip>(eb =>
            {
                eb.HasOne(t => t.User).WithMany().HasForeignKey(t => t.UserId);
                eb.HasMany(t => t.Comments).WithOne(c => c.Trip).HasForeignKey(c => c.TripId).OnDelete(DeleteBehavior.ClientCascade);

            });

            modelBuilder.Entity<Event>(eb =>
            {
                eb.Property(u => u.Start).HasPrecision(3);
                eb.Property(u => u.End).HasPrecision(3);
            });

            modelBuilder.Entity<User>(eb =>
            {
                eb.Property(p => p.Name).IsRequired();
                eb.HasMany(p => p.CommentsList).WithOne(c => c.User);
               
                
            });
            modelBuilder.Entity<Trip>(eb =>
            {
                eb.Property(p => p.Name).IsRequired();
                eb.Property(p => p.CreatedDate).HasPrecision(3);
  

            });
          



        }

    }
}
