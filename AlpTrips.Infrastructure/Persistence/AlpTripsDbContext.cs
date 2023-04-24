using AlpTrips.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace AlpTrips.Infrastructure.Persistence
{
    public class AlpTripsDbContext : IdentityDbContext
    {
        public AlpTripsDbContext(DbContextOptions<AlpTripsDbContext> options) : base(options)
        {

        }
        public DbSet<Trip> Trips { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Trip>().HasOne(t => t.User).WithMany().HasForeignKey(t => t.UserId);

           

            modelBuilder.Entity<User>(eb =>
            {
                eb.Property(p => p.Name).IsRequired();
                eb.HasMany(p => p.TripsList).WithOne(c => c.User);
                eb.HasData(new User() { Id = 1, Email = "dziku@gmail.com", Name = "Dziku" },
                    new User() { Name = "Aga", Id = 2, Email = "aga@w.pl" },
                    new User() { Email = "tomake@w.pl", Id = 3, Name = "Tomek" });
            });
            modelBuilder.Entity<Trip>(eb =>
            {
                eb.Property(p => p.Name).IsRequired();
                eb.Property(p => p.CreatedDate).HasPrecision(3);

                eb.HasData(new Trip()
                {
                    Id = 1,
                    CreatedDate = DateTime.Now,
                    Name = "Weisskugel 3739m npm",
                    Description = "3 najwyższy sczyt Austrii",
                    Level = 2,
                    MountainRange = "Alpy Ötztalskie",
                    Link = "https://dzikumaniak.pl/2022/10/28/weiskugel/",
                    UserId = 1
                },
                    new Trip() { Id = 2, CreatedDate = DateTime.Now, Name = "Weisshorn 4505m npm", Description = "Jeden z trudnijeszych szczytów w Alpach dla średniozaawansowanych", Level = 4, MountainRange = "Alpy Pennińskie", Time = 7, Link = "https://dzikumaniak.pl/2022/08/14/weisshorn-4505m-48h/", UserId = 2 },
                    new Trip() { Id = 3, CreatedDate = DateTime.Now, Name = "Trawers Wildspitze 3768m npm", Description = "Trawers przez Ostgrat", Level = 2, MountainRange = "Alpy Ötztalskie", Link = "https://dzikumaniak.pl/2022/06/08/trawers-wildspitze/", UserId = 3 }
                    );

            });



        }

    }
}
