using Microsoft.AspNetCore.Mvc;

namespace Techaagcompany.web.Controllers
{
    public class TestController : Controller
    {
       static int a=0; 
        public IActionResult ShowButton()
        {
            
            return View();
        }
        public IActionResult ButtonDetail()
        {
            ++a;
            return View("ShowButton",a);
        }
    }
}
