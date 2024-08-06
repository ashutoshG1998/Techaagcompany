using Concertbooking.repositry.Interfaces;
using ConcertBooking.WebHost.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TechAgCompany.Repository.Interfaces;
using TechAsgCompany.Conertbooking.Entities;

namespace ConcertBooking.WebHost.Controllers
{
    public class ConcertsController : Controller
    {
        private readonly IConcertRepo _conRepo;
        private readonly IArtistRepo _artistRepo;
        private readonly IutilityRepo _utilityRepo;
        private readonly IVenveRepo _venveRepo;
        private string containername = "ConcertImage";
        public ConcertsController(IConcertRepo iconRepo, IArtistRepo artistRepo, IutilityRepo utilityRepo, IVenveRepo venveRepo)
        {
            _conRepo = iconRepo;
            _artistRepo = artistRepo;          
            _utilityRepo = utilityRepo;
            _venveRepo = venveRepo;
        }
        public async Task<IActionResult> Index()
        {
            var concerts = await _conRepo.getAll();
            var svm = new List<Concertviewmodel>();
            foreach (var concert in concerts)
            {
                svm.Add(new Concertviewmodel
                {
                    Id = concert.Id,
                    Name = concert.Name,
                    DateTime = concert.DateTime,
                    ArtistName = concert.Artist.Name,
                    VenueName = concert.Venue.Name
                });
            }
            return View(svm);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {   var artist=await _artistRepo.getAll();
            ViewBag.ArtistList = new SelectList(artist, "Id", "Name");
            var Venue = await _venveRepo.GetAll();
            ViewBag.VenueList = new SelectList(Venue, "Id", "Name");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateConcertViewmodel csvm)
        {
            var concerts = new concert
            {
                Name = csvm.Name,
                Description = csvm.Description,
                DateTime = csvm.DateTime,
                VenueId = csvm.VenueId,
                ArtistId = csvm.ArtistId,
              
            };
            if(csvm.Imageurl != null)
            {
                concerts.Imageurl= await _utilityRepo.SaveImage(containername, csvm.Imageurl);            
            }
            await _conRepo.Save(concerts);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {  
            var Concert=await _conRepo.GetById(id);
            var artist = await _artistRepo.getAll();
             var Venue = await _venveRepo.GetAll();
            ViewBag.ArtistList = new SelectList(artist, "Id", "Name");
            ViewBag.VenueList = new SelectList(Venue, "Id", "Name");
            var esvm = new EditConcertViewModel
            {
                Id = Concert.Id,
                Name = Concert.Name,
                Imageurl=Concert.Imageurl,
                DateTime=Concert.DateTime,
                Description=Concert.Description,
                VenueId=Concert.VenueId,
                ArtistId=Concert.ArtistId,    
            };
            return View(esvm);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(EditConcertViewModel esvm)
        {
             var Concert=await _conRepo.GetById(esvm.Id);

                Concert.Id = esvm.Id;
            Concert.Name = esvm.Name;
            Concert.Description = esvm.Description;
            Concert.DateTime = esvm.DateTime;
            Concert.ArtistId = esvm.ArtistId;
            Concert.VenueId = esvm.VenueId;
            
            if(esvm.ChooseImage != null)
            {
                Concert.Imageurl=await _utilityRepo.EditImage(containername,esvm.ChooseImage,Concert.Imageurl);
            }
            await _conRepo.Edit(Concert);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var concert = await _conRepo.GetById(id);
            await _conRepo.RemoveData(concert);
            return View(concert);
        }
        


    }
}
