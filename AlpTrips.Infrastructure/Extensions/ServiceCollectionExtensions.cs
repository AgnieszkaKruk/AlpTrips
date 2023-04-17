using AlpTrips.Domain.Interfaces;
using AlpTrips.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace AlpTrips.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<ITripRepository, TripRepository>();
        }
    }
}
