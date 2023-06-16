using AlpTrips.Domain.Interfaces;
using AlpTrips.Infrastructure.Persistence;
using AlpTrips.Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace AlpTrips.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<ITripRepository, TripRepository>();
            services.AddScoped<ICommentRepository,CommentRepository>();
            services.AddScoped<IUserRepository,UserRepository>();
       
        }
    }
}
