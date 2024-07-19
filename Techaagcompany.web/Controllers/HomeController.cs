using Microsoft.AspNetCore.Mvc;
using System.Collections.Immutable;
using System.Diagnostics;
using Techaagcompany.web.Models;

namespace Techaagcompany.web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            List<People> people = new List<People>();
            people.Add(new People { Id = 1,Name="mahesh",Gender="male" });
            people.Add(new People { Id = 2, Name = "ha", Gender = "M" });

           
            return View("index",people);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
