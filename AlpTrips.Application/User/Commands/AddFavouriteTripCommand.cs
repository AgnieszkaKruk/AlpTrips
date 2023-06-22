﻿using AlpTrips.Application.Dtos;
using MediatR;

namespace AlpTrips.Application.User.Commands
{
    public class AddFavouriteTripCommand : TripDto, IRequest
    {
      public string EncodedName { get; set; }
        public AddFavouriteTripCommand(string encodedName)
        {
            EncodedName = encodedName;
        }


    }
}
