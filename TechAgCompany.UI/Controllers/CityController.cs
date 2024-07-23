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

        public async Task <IActionResult> Index()
        {
           var city= await _cityrepos.GetAll();
            var cvm = new List<CityViewmodel>();
            foreach(var citya in city)
            {
                cvm.Add(new CityViewmodel { Id= citya.Id,CityName= citya.Name,StateName=citya.StateName.Name,
                CountryName=citya.StateName.CountryName.Name});
            }
            return View(cvm);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var state=await _staterepos.GetAll();
            ViewBag.StateList = new SelectList(state, "Id", "Name");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateCityViewModel cvm)
        {
            City city = new City()
            {
                Name=cvm.cityName,
                StateId=cvm.StateId
            };
            await _cityrepos.save(city);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var city= await _cityrepos.GetById(id);
            var state =await _staterepos.GetAll();
            ViewBag.StateList = new SelectList(state, "Id", "Name");
            return View(city);
        }
        [HttpPost]
        public async Task<IActionResult>  Edit(City city)
        {
            await _cityrepos.Edit(city);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult>  Delete(int id)
        {
           var cityD= await _cityrepos.GetById(id);
            return View(cityD) ;
        }
        [HttpPost]
        public async Task<IActionResult> Delete(City city)
        {
            await _cityrepos.RemoveData(city);
            return RedirectToAction("Index");
        }
    }
}
