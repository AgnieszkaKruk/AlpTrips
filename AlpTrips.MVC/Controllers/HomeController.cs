using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AlpsTrips.MVC.Models;

namespace AlpsTrips.MVC.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
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
}
