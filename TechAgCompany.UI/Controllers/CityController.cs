using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TechAgCompany.Entities;
using TechAgCompany.Repository.Interfaces;

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
            return View(city);
        }
        [HttpGet]
        public IActionResult Create()
        {
            var state= _staterepos.GetAll();
            ViewBag.StateList = new SelectList(state, "Id", "Name");
            return View();
        }
        [HttpPost]
        public IActionResult Create(City city)
        {
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
