using AlpTrips.Application.Trip.Commands.CreateTrip;
using AlpTrips.Application;
using AlpTrips.Application.User.Commands;
using AlpTrips.Application.User.Commands.AddFavouriteTrip;
using AlpTrips.Application.User.Queries;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;
using AlpTrips.Application.User.Commands.AddEvent;
using AlpTrips.Application.User.Queries.UserTrips;
using AlpTrips.Application.User.Queries.UserFavouriteTrips;
using AlpTrips.Application.User.Queries.UserEvents;

namespace AlpsTrips.MVC.Controllers
{
    public class UserController : Controller
    {
        private readonly IMediator _mediator;
        public UserController(IMediator mediator)
        {
            _mediator = mediator;   
        }
        [HttpGet]
        public async Task <IActionResult> UserTrips ()
        {
            var userTrips = await _mediator.Send(new UserTripsQuery());
            return View(userTrips);
        }
      
        public async Task<IActionResult> AddToFavourite(string encodedName)
        {
            var result = await _mediator.Send(new AddFavouriteTripCommand(encodedName));
            return RedirectToAction(nameof(UserFavouriteTrips));
        }

        public async Task<IActionResult> UserFavouriteTrips()
        {
            var userfavouriteTrips = await _mediator.Send(new UserFavouriteTripsQuery());
            return View(userfavouriteTrips);
        }

      
        [Authorize]
        public IActionResult CreateEvent(bool isSuccess = false)
        {
            ViewBag.IsSuccess = isSuccess;


            return View();

        }


        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateEvent(AddEventCommand addEventCommand)
        {

            if (!ModelState.IsValid)
            {
                return View("Create", addEventCommand);
            }
            else
            {
                await _mediator.Send(addEventCommand);
                return RedirectToAction(nameof(UserEvents), new { isSuccess = true });
            }
        }


        public async Task<IActionResult> UserEvents()
        {
            var userEvents = await _mediator.Send(new UserEventsQuery());
            return View(userEvents);
        }
    }
}
