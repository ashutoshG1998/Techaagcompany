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

        public IActionResult Index()
        {
            List<CountryViewModel> cvm = new List<CountryViewModel>();
            var countries = _icountryRepos.GetAll();

            foreach (var country in countries)
            {
                cvm.Add(new CountryViewModel { Id = country.Id, Name = country.Name });
            }
            return View(cvm);
        }
        [HttpGet]
        public IActionResult Create()
        {
            //Country country = new Country();
            CreateCountryviewmodel country = new CreateCountryviewmodel();
            return View(country);
        }
        [HttpPost]
        public IActionResult Create(CreateCountryviewmodel vm)
        {
            var country = new Country
            {
                Name = vm.Name
            };
            _icountryRepos.save(country);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var country = _icountryRepos.GetById(id);
            CountryViewModel cvm = new CountryViewModel()
            {
                Id = country.Id,
                Name = country.Name
            };
            
            return View(cvm);
        }
        [HttpPost]
        public IActionResult Edit(CountryViewModel vm)
        {
            Country country = new Country()
            {
                Id = vm.Id,
                Name = vm.Name
            };
            _icountryRepos.Edit(country);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var country = _icountryRepos.GetById(id);
            return View(country);
        }
        [HttpPost]
        public IActionResult Delete(Country country)
        {
            _icountryRepos.RemoveData(country);
            return RedirectToAction("Index");
        }
    }
}
