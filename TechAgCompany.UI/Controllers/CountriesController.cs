using Microsoft.AspNetCore.Mvc;
using TechAgCompany.Entities;
using TechAgCompany.Repository.Interfaces;

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
            var countries= _icountryRepos.GetAll();
            return View(countries);
        }
        [HttpGet]
        public IActionResult Create()
        {
            Country country = new Country();
            return View(country);
        }
        [HttpPost]
        public IActionResult Create(Country country)
        {
            _icountryRepos.save(country);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var country=_icountryRepos.GetById(id);
            return View(country);
        }
        [HttpPost]
        public IActionResult Edit(Country country)
        {
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
