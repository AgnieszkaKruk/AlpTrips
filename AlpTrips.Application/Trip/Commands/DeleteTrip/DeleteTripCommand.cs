using AlpTrips.Application.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlpTrips.Application.Trip.Commands.DeleteTrip
{
    public class DeleteTripCommand : TripDto, IRequest
    {
    }
}
