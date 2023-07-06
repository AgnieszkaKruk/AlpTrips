
using AlpsTrips.MVC.Models;
using AlpTrips.Application;
using AlpTrips.Application.Comment.Commands.CreateComment;
using AlpTrips.Application.Comment.Queries.GetAllCommentsQuery;
using AlpTrips.Application.Comment.Queries.GetCommentsForTripQuery;
using AlpTrips.Application.Dtos;
using AlpTrips.Application.Trip.Commands.CreateTrip;
using AlpTrips.Application.Trip.Commands.DeleteTrip;
using AlpTrips.Application.Trip.Commands.EditTrip;
using AlpTrips.Application.Trip.Queries.FindBestWeather;
using AlpTrips.Application.Trip.Queries.GetAllTrips;
using AlpTrips.Application.Trip.Queries.GetTripByEncodedName;
using AlpTrips.Application.Trip.Queries.SearchTripByParam;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AlpsTrips.MVC.Controllers
{
    public class TripController : Controller
    {

        private IWebHostEnvironment _webHostEnviroment;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;


        public TripController(IWebHostEnvironment webHostEnviroment, IMediator mediator, IMapper mapper)
        {
            _webHostEnviroment = webHostEnviroment;
            _mediator = mediator;
            _mapper = mapper;
        }


        // GET: Trip
        public async Task<IActionResult> Index(bool isSuccess = false)

        {
            ViewBag.IsSuccess = isSuccess;

            var allTrips = await _mediator.Send(new GetAllTripsQuery());
            return View(allTrips);
        }




        // GET: Trip/encodedName/Details

        [Route("Trip/{encodedName}/Details")]
        public async Task<IActionResult> Details(string encodedName)
        {
            var trip = await _mediator.Send(new GetTripByEncodedNameQuery(encodedName));
            ViewBag.UserId = trip.CreatedById;
            var tripDto = await _mediator.Send(new GetTripDtoByEncodedNameQuery(encodedName));
            ViewBag.EncodedName = tripDto.EncodedName;

            var comments = await _mediator.Send(new GetCommentsForTripQuery(encodedName));
            ViewBag.Comments = comments;

            var ratings = await _mediator.Send(new GetCommentsForTripQuery(encodedName));
            if (ratings.Count() > 0)
            {
                var ratingSum = ratings.Sum(d => d.Rate);
                ViewBag.RatingSum = ratingSum;
                var ratingCount = ratings.Count();
                ViewBag.RatingCount = ratingCount;
            }
            else
            {
                ViewBag.RatingSum = 0;
                ViewBag.RatingCount = 0;
            }


            return View(tripDto);
        }

        [Authorize]
        [Route("Trip/{encodedName}/Details/Comments/Create")]
        public async Task<IActionResult> CommentForTrip(CreateCommentCommand createCommentCommand, string encodedName)
        {
            var trip = await _mediator.Send(new GetTripByEncodedNameQuery(encodedName));
            var tripId = trip.Id;
            createCommentCommand.TripId = tripId;
            await _mediator.Send(createCommentCommand);
            return RedirectToAction(nameof(Details), new { encodedName });

        }

        // GET: Trip/Create
        [Authorize]
        public IActionResult Create(bool isSuccess = false)
        {
            ViewBag.IsSuccess = isSuccess;


            return View();

        }



        // POST: Trip
        // /Create
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(CreateTripCommand createTripCommand, [FromServices] IValidator<CreateTripCommand> validator, string latitude, string longitude)
        {

            if (!ModelState.IsValid)
            {
                return View("Create", createTripCommand);
            }
            else
            {
                if (createTripCommand.ImageFile != null)
                {
                    string folder = "images/";
                    createTripCommand.ImageUrl = await UploadImage(createTripCommand, folder);
                }

                if (createTripCommand.GalleryFiles != null)
                {
                    string folder = "gallery/";
                    createTripCommand.Gallery = new List<GalleryDto>();

                    foreach (var file in createTripCommand.GalleryFiles)
                    {
                        var gallery = new GalleryDto()
                        {
                            Name = file.FileName,
                            Url = folder + Guid.NewGuid().ToString() + "_" + file.FileName

                        };
                        string serverFolder = Path.Combine(_webHostEnviroment.WebRootPath, gallery.Url);
                        file.CopyToAsync(new FileStream(serverFolder, FileMode.Create));
                      
                        createTripCommand.Gallery.Add(gallery);
                    }

                }
             

                await _mediator.Send(createTripCommand);
                return RedirectToAction(nameof(Index), new { isSuccess = true });
            }
        }
        private async Task<string> UploadImage(CreateTripCommand createTripCommand, string folderPath)
        {

            folderPath += Guid.NewGuid().ToString() + "_" + createTripCommand.ImageFile.FileName;

            string serverFolder = Path.Combine(_webHostEnviroment.WebRootPath, folderPath);

            await createTripCommand.ImageFile.CopyToAsync(new FileStream(serverFolder, FileMode.Create));

            return "/" + folderPath;
        }




        // GET: Trip/encodedName/Edit
        [HttpGet]
        [Route("Trip/{encodedName}/Edit")]
        [Authorize]
        public async Task<IActionResult> Edit(string encodedName)
        { 
            var tripDto = await _mediator.Send(new GetTripDtoByEncodedNameQuery(encodedName));
            return View(tripDto);
        }



        // POST: Trip/encodedName/Edit
        [HttpPost]
        [Route("Trip/{encodedName}/Edit")]
        [Authorize]
        public async Task<IActionResult> Edit(string encodedName, EditTripCommand editTripCommand, [FromServices] IValidator<EditTripCommand> validator, string latitude, string longitude)
        {

            if (!ModelState.IsValid)
            {
                return View("Edit", editTripCommand);
            }
            else
            {
                if (editTripCommand.ImageFile != null)
                {
                    string folder = "images/";
                    folder += Guid.NewGuid().ToString() + "_" + editTripCommand.ImageFile.FileName;

                    editTripCommand.ImageUrl = "/" + folder;
                    string serverFolder = Path.Combine(_webHostEnviroment.WebRootPath, folder);

                    await editTripCommand.ImageFile.CopyToAsync(new FileStream(serverFolder, FileMode.Create));
                }
                if (editTripCommand.GalleryFiles != null)
                {
                    string folder = "gallery/";
                    editTripCommand.Gallery = new List<GalleryDto>();

                    foreach (var file in editTripCommand.GalleryFiles)
                    {
                        var gallery = new GalleryDto()
                        {
                            Name = file.FileName,
                            Url = folder + Guid.NewGuid().ToString() + "_" + file.FileName

                        };
                        string serverFolder = Path.Combine(_webHostEnviroment.WebRootPath, gallery.Url);
                        file.CopyToAsync(new FileStream(serverFolder, FileMode.Create));

                        editTripCommand.Gallery.Add(gallery);
                    }

                }

                await _mediator.Send(editTripCommand);
                return RedirectToAction(nameof(Index));
            }
        }


        [Route("Trip/{encodedName}/Delete")]
        [Authorize]
        public async Task<IActionResult> Delete(string encodedName, DeleteTripCommand deleteTripCommand)
        {
            var tripDto = await _mediator.Send(deleteTripCommand);
            return RedirectToAction(nameof(Index));

        }

        [HttpPost]
        [Route("Trip/{encodedName}/Delete")]
        [Authorize]
        public async Task<IActionResult> DeleteConfirm(string encodedName, DeleteTripCommand deleteTripCommand)
        {
            var tripDto = await _mediator.Send(deleteTripCommand);
            return RedirectToAction(nameof(Index));

        }


        [HttpGet]    
        public IActionResult SearchByParam()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SearchByParam(int? level, string? length, string? elevation, string? time)
        {
            var tripDtos = await _mediator.Send(new SearchTripByParamQuery(level,length,elevation, time));
            return View("SearchResults",tripDtos);
        }

        
        public async Task<IActionResult> SearchResults(IEnumerable<TripDto> tripDtos)
        {
            return View(tripDtos);
        }

        [HttpPost]
        public IActionResult CountTime(int length, int elevation, int speed, int elevationSpeed, string encodedName)
        {
            var elevationInKm = (double)elevation / 1000;
            var elevationSpeedInKm = (double)elevationSpeed / 1000;
            var timee = length / speed + elevationInKm / elevationSpeedInKm;
            var time = Math.Round(timee, 2);
            string timeDistance = $"Twój orientacyjny czas przejścia to {time} godzin";

            TempData["Time"] = timeDistance;

            return RedirectToAction(nameof(Details), new { encodedName = encodedName });
        }

        public async Task<IActionResult> FindBestWeather(DateTime start,DateTime end)
        {
            var tripDtoNow= await _mediator.Send(new FindBestWeatherNowQuery());   
            var tripDtoNextWeek = await _mediator.Send(new FindBestWeatherNextWeekQuery());
            var tripDtoInDates = await _mediator.Send(new FindBestWeatherInDatesQuery(start,end));
           
            TripsViewModel viewModel = new TripsViewModel
            {
                TripDto1 = tripDtoNow,
                TripDto2 = tripDtoNextWeek,
                TripDto3 = tripDtoInDates
            };
            return View(viewModel);

        }







    }
}


