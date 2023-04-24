using AlpTrips.Application.Dtos;
using AlpTrips.Domain.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AlpsTrips.MVC.Components
{
    public class TopTrasyViewComponent : ViewComponent
    {
        private readonly ITripRepository _tripRepository;
        private readonly IMapper _mapper;

        public TopTrasyViewComponent(ITripRepository tripRepository, IMapper mapper)
        {
           _tripRepository = tripRepository;
            _mapper = mapper;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var trips = await _tripRepository.GetTop6Trips();
            var tripsDto = _mapper.Map<IEnumerable<TripDto>>(trips);

            return View(tripsDto);
        }
    }
}
