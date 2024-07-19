using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics.Metrics;
using TechAgCompany.Entities;
using TechAgCompany.Repository.Interfaces;

namespace TechAgCompany.UI.Controllers
{
    public class StateController : Controller
    {

        private readonly IStateRepo _stateRepo;
        private readonly IcountryRepos _icountryRepos;

        public StateController(IStateRepo stateRepo, IcountryRepos icountryRepos)
        {
            _stateRepo = stateRepo;
            _icountryRepos = icountryRepos;
        }

        public IActionResult Index()
        {
            var state=_stateRepo.GetAll(); 
            return View(state);
        }
        [HttpGet]
        public IActionResult Create()
        {
            var country= _icountryRepos.GetAll();
            ViewBag.CountryList = new SelectList(country,"Id", "Name");
            return View();
        }
        [HttpPost]
        public IActionResult Create(State state)
        {
           _stateRepo.save(state);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var state = _stateRepo.GetById(id);
            var country = _icountryRepos.GetAll();
            ViewBag.CountryList = new SelectList(country, "Id", "Name");
            return View(state);
        }
        [HttpPost]
        public IActionResult Edit(State state)
        {
            _stateRepo.Edit(state);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var Dstate =_stateRepo.GetById(id);
            return View(Dstate);  
        }
        [HttpPost]
        public IActionResult Delete(State state)
        {
            _stateRepo.RemoveData(state);
            return RedirectToAction("Index");
        }

    }
}
