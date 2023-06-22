using AlpTrips.Application.User.Commands;
using AlpTrips.Application.User.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

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
    }
}
