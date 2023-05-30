using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AlpsTrips.MVC.Models;
using Microsoft.AspNetCore.Identity;
using AlpTrips.Application.Trip.Commands.EditTrip;
using FluentValidation;
using AlpTrips.Application.Trip.Queries.GetTripByEncodedName;
using AutoMapper;
using MediatR;
using AlpTrips.Application.Dtos;
using AlpTrips.Application.Trip.Queries.SearchTripQuery;

namespace AlpsTrips.MVC.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public HomeController(ILogger<HomeController> logger, IMediator mediator, IMapper mapper)
    {
        _logger = logger;
        _mediator = mediator;
        _mapper = mapper;

    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult About()
    {
        var About = new About()
        {
            Title = "About",
            Description = "Strona o wycieczkach po Alpach",
            Tags = new List<string>() { "góry", "Alpy", "wycieczki" }
        };
        return View(About);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    public IActionResult Logout()
    {

        TempData["logout_message"] = "Zostałeś wylogowany.";

        return RedirectToAction("Index");
    }

    public IActionResult Register()
    {
        TempData["register_message"] = "Zostałeś zarejestrowany.";
        return RedirectToAction("Index");

    }

    public async Task<IActionResult> Search(string search)
    {
        var tripsDto = await _mediator.Send(new SearchTripQuery(search));

        return View(tripsDto);

    }
}
    