using Microsoft.AspNetCore.Mvc;
using TechAgCompany.Repository.Interfaces;

namespace TechAgCompany.UI.ViewComponents
{
    public class CountStateViewComponent:ViewComponent
    {

        private IStateRepo _stateRepo;

        public CountStateViewComponent(IStateRepo stateRepo)
        {
            _stateRepo = stateRepo;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var states = await _stateRepo.GetAll();
            int countstat =states.Count();
            return View(countstat);
        }
    }
}
