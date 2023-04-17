using AlpTrips.Application.Dtos;
using AlpTrips.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace AlpTrips.Application.Services
{
    public interface ITripService
    {
        Task Create(TripDto tripDto);

    }
}