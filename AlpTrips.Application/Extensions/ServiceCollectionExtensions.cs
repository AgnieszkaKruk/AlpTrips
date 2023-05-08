using AlpTrips.Application.ApplicationUser;
using AlpTrips.Application.Comment.Commands.CreateComment;
using AlpTrips.Application.Dtos;
using AlpTrips.Application.Mappings;
using AlpTrips.Application.Trip.Commands.CreateTrip;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace AlpTrips.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddApplication(this IServiceCollection services)
        {
            
            services.AddAutoMapper(typeof(MappingProfile));

            services.AddValidatorsFromAssemblyContaining<CreateTripCommandValidator>()
                .AddFluentValidationAutoValidation()
                .AddFluentValidationClientsideAdapters();

            services.AddValidatorsFromAssemblyContaining<TripDto>();
            
            services.AddMediatR(typeof(CreateTripCommand));
            services.AddMediatR(typeof(CreateCommentCommand));



            services.AddScoped<IUserContext,UserContext>();
               



        }
    }
}
