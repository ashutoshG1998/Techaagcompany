using Microsoft.AspNetCore.Mvc;
using TechAgCompany.Entities;
using TechAgCompany.Repository.Interfaces;
using TechAgCompany.UI.ViewModel.CountryViewModel;
using TechAgCompany.UI.ViewModel.SkillViewModel;

namespace TechAgCompany.UI.Controllers
{
    public class SkillController : Controller
    {
        private readonly ISkillRepo _skillRepo;

        public SkillController(ISkillRepo skillRepo)
        {
            _skillRepo = skillRepo;
        }

        public async Task<IActionResult> Index()
        {

            List<SkillViewModel> cvm = new List<SkillViewModel>();
            var skills = await _skillRepo.GetAll();

            foreach (var skill in skills)
            {
                cvm.Add(new SkillViewModel { Id = skill.Id, Item = skill.Item });
            }
            return View(cvm);
        }
    
           
        
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

   

        [HttpPost]
        public async Task<IActionResult> Create(CreateSkillViewModel vm)
        {
            var skill = new Skill
            {
                Item = vm.Item,
            };
            await _skillRepo.save(skill);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var skill = await _skillRepo.GetById(id);
            SkillViewModel cvm = new SkillViewModel()
            {
                Id = skill.Id,
               Item=skill.Item,
            };

            return View(cvm);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(SkillViewModel vm)
        {
            Skill country = new Skill()
            {
                Id = vm.Id,
                Item = vm.Item
            };
            await _skillRepo.Edit(country);
            return RedirectToAction("Index");
        }
        [HttpGet]
       
        public async Task<IActionResult> Delete(Country country)
        {
            var skill =await _skillRepo.GetById(country.Id);
            await _skillRepo.RemoveData(skill);
            return RedirectToAction("Index");
        }
    }
}
