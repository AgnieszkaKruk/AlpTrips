using AlpTrips.Application.Dtos;
using AlpTrips.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlpTrips.Application.User.Commands.AddEvent
{
    public class AddEventCommand : Domain.Entities.Event, IRequest
    {
    }
}
