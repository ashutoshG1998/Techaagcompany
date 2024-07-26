using Microsoft.AspNetCore.Mvc;
using TechAgCompany.Entities;
using TechAgCompany.Repository.Interfaces;
using TechAgCompany.UI.ViewModel.CountryViewModel;

namespace TechAgCompany.UI.Controllers
{
    public class CountriesController : Controller
    {
        private readonly IcountryRepos _icountryRepos;

        public CountriesController(IcountryRepos icountryRepos)
        {
            _icountryRepos = icountryRepos;
        }

       
        public async Task <IActionResult> Index()
        {
            if (HttpContext.Session.GetInt32("userId") != null)
            {
                List<CountryViewModel> cvm = new List<CountryViewModel>();
                var countries = await _icountryRepos.GetAll();

                foreach (var country in countries)
                {
                    cvm.Add(new CountryViewModel { Id = country.Id, Name = country.Name });
                }
                return View(cvm);
            }
            return RedirectToAction("Login", "Auth");
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            //Country country = new Country();
            CreateCountryviewmodel country = new CreateCountryviewmodel();
            return View(country);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateCountryviewmodel vm)
        {
            var country = new Country
            {
                Name = vm.Name
            };
            await _icountryRepos.save(country);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var country = await _icountryRepos.GetById(id);
            CountryViewModel cvm = new CountryViewModel()
            {
                Id = country.Id,
                Name = country.Name
            };
            
            return View(cvm);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(CountryViewModel vm)
        {
            Country country = new Country()
            {
                Id = vm.Id,
                Name = vm.Name
            };
            await _icountryRepos.Edit(country);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var country = await _icountryRepos.GetById(id);
            return View(country);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(Country country)
        {
            await _icountryRepos.RemoveData(country);
            return RedirectToAction("Index");
        }
    }
}
