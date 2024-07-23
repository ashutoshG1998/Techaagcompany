
using Microsoft.AspNetCore.Mvc;
using TechAgCompany.Repository.Interfaces;

namespace TechAgCompany.UI.ViewComponents
{
    public class CountCountryViewComponent :ViewComponent
    {
        private IcountryRepos _icountryRepos;

        public CountCountryViewComponent(IcountryRepos icountryRepos)
        {
            _icountryRepos = icountryRepos;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {

            var country =await _icountryRepos.GetAll();
            int countcountry = country.Count();
            return View(countcountry);
        }
    }
}
