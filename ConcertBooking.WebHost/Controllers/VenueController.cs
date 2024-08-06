using Concertbooking.repositry.Interfaces;
using ConcertBooking.WebHost.ViewModel;
using Microsoft.AspNetCore.Mvc;
using TechAsgCompany.Conertbooking.Entities;

namespace ConcertBooking.WebHost.Controllers
{
    public class VenueController : Controller
    {
        private readonly IVenveRepo _Ivenverepo;

        public VenueController(IVenveRepo ivenverepo)
        {
            _Ivenverepo = ivenverepo;
        }

        public async Task<IActionResult> Index()
        { 
                var venues = await _Ivenverepo.GetAll();
              var cvm = new List<VenueViewmodel>();
            foreach (var venue in venues)
                {
                    cvm.Add(new VenueViewmodel { 
                        Id = venue.Id, 
                        Name = venue.Name,
                        Address=venue.Address,
                        seatCapacity=venue.seatCapacity });
                }
                return View(cvm); 
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
           
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateVenueviewmodel vm)
        {
            var venue = new Venue
            {
                Name = vm.Name
                ,Address = vm.Address
                ,seatCapacity = vm.seatCapacity 
            };
            await _Ivenverepo.Save(venue);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var country = await _Ivenverepo.GetById(id);
            VenueViewmodel cvm = new VenueViewmodel()
            {
                Id = country.Id,
                Name = country.Name,
                Address = country.Address,
                seatCapacity = country.seatCapacity
            };

            return View(cvm);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(VenueViewmodel vm)
        {
            Venue venues = new Venue()
            {
                Id = vm.Id,
                Name = vm.Name
            };
            await _Ivenverepo.Edit(venues);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var venue = await _Ivenverepo.GetById(id);
            await _Ivenverepo.RemoveData(venue);
            return View(venue);
        }
        //[HttpPost]
        //public async Task<IActionResult> Delete(Venue venue)
        //{
        //    await _Ivenverepo.RemoveData(venue);
        //    return RedirectToAction("Index");
        //}
    }
}
