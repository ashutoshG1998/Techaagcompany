using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption;
using Microsoft.AspNetCore.Mvc;
using TechAgCompany.Entities;
using TechAgCompany.Repository.Interfaces;
using TechAgCompany.UI.ViewModel.UserinfoViewModel;

namespace TechAgCompany.UI.Controllers
{
    public class AuthController : Controller
    {
        private readonly IUserinfo _userinfo;

        public AuthController(IUserinfo userinfo)
        {
            _userinfo = userinfo;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(UserInforViewModel uiv)
        {
            var model = new userInfo
            {
                UserName = uiv.userName,
                Password = uiv.password,
            };
            await _userinfo.Registeruser(model);
            return RedirectToAction("Login");
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(UserInforViewModel vm)
        {
            var userinfo = await _userinfo.Getuserinfo(vm.userName, vm.password);
            HttpContext.Session.SetInt32("userId", userinfo.UserId);
            HttpContext.Session.SetString("userName", userinfo.UserName);
            return RedirectToAction("Index", "Countries");
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
