
using AlpTrips.Application.Trip.Commands.CreateTrip;
using AlpTrips.Application.Trip.Commands.DeleteTrip;
using AlpTrips.Application.Trip.Commands.EditTrip;
using AlpTrips.Application.Trip.Queries.GetAllTrips;
using AlpTrips.Application.Trip.Queries.GetTripByEncodedName;
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
            var tripDto = await _mediator.Send(new GetTripByEncodedNameQuery(encodedName));
            return View(tripDto);
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
        public async Task<IActionResult> Create(CreateTripCommand createTripCommand, [FromServices] IValidator<CreateTripCommand> validator)
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
                    folder += Guid.NewGuid().ToString() + "_" + createTripCommand.ImageFile.FileName;

                    createTripCommand.ImageUrl = "/" + folder;
                    string serverFolder = Path.Combine(_webHostEnviroment.WebRootPath, folder);

                    await createTripCommand.ImageFile.CopyToAsync(new FileStream(serverFolder, FileMode.Create));
                }
                await _mediator.Send(createTripCommand);
                return RedirectToAction(nameof(Index), new { isSuccess = true });


            }


        }



        // GET: Trip/encodedName/Edit
        [HttpGet]
        [Route("Trip/{encodedName}/Edit")]
        [Authorize]
        public async Task<IActionResult> Edit(string encodedName)
        {
            var tripDto = await _mediator.Send(new GetTripByEncodedNameQuery(encodedName));
            EditTripCommand model = _mapper.Map<EditTripCommand>(tripDto);
            return View(model);
        }



        // POST: Trip/encodedName/Edit
        [HttpPost]
        [Route("Trip/{encodedName}/Edit")]
        [Authorize]
        public async Task<IActionResult> Edit(string encodedName, EditTripCommand editTripCommand, [FromServices] IValidator<EditTripCommand> validator)
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





    }
}
