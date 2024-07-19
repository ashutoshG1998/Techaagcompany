using Microsoft.AspNetCore.Mvc;
using Techaagcompany.web.Models;

namespace Techaagcompany.web.Controllers
{
    public class PeopleController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PeopleController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var people=_context.People.ToList();
            return View(people);
        }

        [HttpGet]
        public IActionResult Create()
        {
            
            return View();
        }
        [HttpPost]
        public IActionResult Create(People people)
        {
            _context.People.Add(people);
            _context.SaveChanges();
            return RedirectToAction("index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var people=_context.People.Find(id);
            return View(people);
        }
        public IActionResult Edit(People people)
        {
            _context.People.Update(people);
            _context.SaveChanges();
            return RedirectToAction("index");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var people = _context.People.Find(id);
            return View(people);
        }
        [HttpPost]
        public IActionResult Delete(People people)
        {
            _context.People.Remove(people);
            _context.SaveChanges();
            return RedirectToAction("index");
        }
    }
}
