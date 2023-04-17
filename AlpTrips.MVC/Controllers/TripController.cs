using AlpTrips.Application.Dtos;
using AlpTrips.Application.Services;
using AlpTrips.Infrastructure.Persistence;
using AlpTrips.Infrastructure.Repositories;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AlpsTrips.MVC.Controllers
{
    public class TripController : Controller
    {
        private readonly ITripService _tripService;
        private IWebHostEnvironment _webHostEnviroment;
        public TripController(ITripService tripService, IWebHostEnvironment webHostEnviroment)
        {
            _tripService = tripService;
            _webHostEnviroment = webHostEnviroment;
        }
        // GET: TripController
        //public async Task<IActionResult> Index()
        //{
        //    return View(await _tripService.Trips.ToListAsync());
        //}

        // GET: TripController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Trip/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Trip/Create
        [HttpPost]
  
        public  async Task<IActionResult> Create(TripDto tripDto)
        {

            if (!ModelState.IsValid)
            {
                return View(tripDto);
            }

            if (tripDto.ImageFile != null)
            {
                string folder = "images/";
                folder += Guid.NewGuid().ToString() +"_"+ tripDto.ImageFile.FileName;

                tripDto.ImageUrl = "/"+ folder;
                string serverFolder = Path.Combine(_webHostEnviroment.WebRootPath, folder);

                await tripDto.ImageFile.CopyToAsync(new FileStream(serverFolder, FileMode.Create));
            }
            await _tripService.Create(tripDto);
            return RedirectToAction(nameof(Create));   
        }

        // GET: TripController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TripController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TripController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TripController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
