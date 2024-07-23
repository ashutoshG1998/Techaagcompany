using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics.Metrics;
using TechAgCompany.Entities;
using TechAgCompany.Repository.Interfaces;
using TechAgCompany.UI.ViewModel.StateViewmodel;

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

        public async Task<IActionResult>Index()
        {
            var state=await _stateRepo.GetAll();
            List<StateViewmodel> svm = new List<StateViewmodel>();
            foreach(var stname in state)
            {
                svm.Add(new StateViewmodel { Id = stname.Id, StateName = stname.Name, CountryName = stname.CountryName.Name });
            }
            return View(svm);
        }
        [HttpGet]
        public async Task<IActionResult>  Create()
        {
            
            var country= await _icountryRepos.GetAll();
            ViewBag.CountryList = new SelectList(country,"Id", "Name");
            return View();
        }
        [HttpPost]
        public async  Task<IActionResult> Create(CreateStateviewmodel csvm)
        {
            var state = new State
            {
                Name=csvm.StateName,
                CountryId=csvm.CountryId
            };
           await _stateRepo.save(state);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var state = await _stateRepo.GetById(id);
            var country =await _icountryRepos.GetAll();
            EditStateviewmodel esvm = new EditStateviewmodel
            {
                Id = state.Id,
                StateName = state.Name,
                CountryId = state.CountryId
            };
            ViewBag.CountryList = new SelectList(country, "Id", "Name");
            return View(esvm);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(EditStateviewmodel esvm)
        {
            State state = new State
            {
                Id=esvm.Id,
                Name=esvm.StateName,
                CountryId=esvm.CountryId
            };
            await _stateRepo.Edit(state);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var Dstate =await _stateRepo.GetById(id);
            return View(Dstate);  
        }
        [HttpPost]
        public async Task<IActionResult> Delete(State state)
        {
            await _stateRepo.RemoveData(state);
            return RedirectToAction("Index");
        }

    }
}
