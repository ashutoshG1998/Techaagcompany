using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TechAgCompany.Entities;
using TechAgCompany.Repository.Interfaces;
using TechAgCompany.UI.ViewModel.CityViewModel;

namespace TechAgCompany.UI.Controllers
{
    public class CityController : Controller
    {
        private readonly ICityRepos _cityrepos;
        private readonly IStateRepo _staterepos;

        public CityController(ICityRepos cityrepos, IStateRepo staterepos)
        {
            _cityrepos = cityrepos;
            _staterepos = staterepos;
        }

        public IActionResult Index()
        {
           var city= _cityrepos.GetAll();
            var cvm = new List<CityViewmodel>();
            foreach(var citya in city)
            {
                cvm.Add(new CityViewmodel { Id= citya.Id,CityName= citya.Name,StateName=citya.StateName.Name,
                CountryName=citya.StateName.CountryName.Name});
            }
            return View(cvm);
        }
        [HttpGet]
        public IActionResult Create()
        {
            var state= _staterepos.GetAll();
            ViewBag.StateList = new SelectList(state, "Id", "Name");
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateCityViewModel cvm)
        {
            City city = new City()
            {
                Name=cvm.cityName,
                StateId=cvm.StateId
            };
            _cityrepos.save(city);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var city= _cityrepos.GetById(id);
            var state = _staterepos.GetAll();
            ViewBag.StateList = new SelectList(state, "Id", "Name");
            return View(city);
        }
        [HttpPost]
        public IActionResult Edit(City city)
        {
            _cityrepos.Edit(city);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
           var cityD= _cityrepos.GetById(id);
            return View(cityD) ;
        }
        [HttpPost]
        public IActionResult Delete(City city)
        {
            _cityrepos.RemoveData(city);
            return RedirectToAction("Index");
        }
    }
}
