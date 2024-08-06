using Concertbooking.repositry.Interfaces;
using ConcertBooking.WebHost.ViewModel;
using Microsoft.AspNetCore.Mvc;
using TechAgCompany.Repository.Interfaces;
using TechAsgCompany.Conertbooking.Entities;

namespace ConcertBooking.WebHost.Controllers
{
    public class ArtistController : Controller
    {
        private readonly IArtistRepo _artistRepo;
        private readonly IutilityRepo _utilityrepo;
        private string containerName = "ArtistImage";

        public ArtistController(IArtistRepo artistRepo, IutilityRepo utilityrepo)
        {
            _artistRepo = artistRepo;
            _utilityrepo = utilityrepo;
        }

        public async Task<IActionResult> Index()
        {
            List<ArtistViewModel> cvm = new List<ArtistViewModel>();

            var artists = await _artistRepo.getAll();

            foreach (var artist in artists)
            {
                cvm.Add(new ArtistViewModel
                {
                    Id = artist.Id,
                    Name = artist.Name,
                    Bio = artist.Bio,
                    Image = artist.ImageUrl,

                });
            }
            return View(cvm);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateArtistViewModel vm)
        {
            var artist = new Artist
            {
                Name = vm.Name
               ,
                Bio = vm.Bio,
            };
            if (vm.ImageUrl != null)
            {
                artist.ImageUrl = await _utilityrepo.SaveImage(containerName, vm.ImageUrl);
            }
            await _artistRepo.Save(artist);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var country = await _artistRepo.GetById(id);
            EditArtistViewModel cvm = new EditArtistViewModel()
            {
                Id = country.Id,
                Name = country.Name,
                Bio = country.Bio,
                ImageUrl = country.ImageUrl
            };

            return View(cvm);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(EditArtistViewModel vm)
        {
            var artist = await _artistRepo.GetById(vm.Id);
            artist.Name = vm.Name;
            artist.Bio = vm.Bio;
            if (vm.ChooseImageUrl != null)
            {
                artist.ImageUrl = await _utilityrepo.EditImage(containerName, vm.ChooseImageUrl, artist.ImageUrl);
            }
            await _artistRepo.Edit(artist);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var artist = await _artistRepo.GetById(id);
            await _artistRepo.RemoveData(artist);
            return RedirectToAction("Index");
        }


    }
}
