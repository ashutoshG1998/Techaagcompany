using Microsoft.AspNetCore.Mvc;
using TechAgCompany.Repository.Interfaces;

namespace TechAgCompany.UI.ViewComponents
{
   
   
    public class CountCityViewComponent : ViewComponent
    {
        private ICityRepos _cityRepos;

        public CountCityViewComponent(ICityRepos cityRepos)
        {
            _cityRepos = cityRepos;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        { 
            var cities= await _cityRepos.GetAll();
            int citycount= cities.Count();
            return View(citycount);
        }
    }
}
