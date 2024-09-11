using Concertbooking.repositry.Interfaces;
using ConcertBooking.Infrastructure;
using Conertbooking.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concertbooking.repositry.Implementaion
{
    public class Dbinitial : IDbinitial
    {
        private UserManager<ApplicationUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;

        public Dbinitial(UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public Task seed()
        {
            
                if (!_roleManager.RoleExistsAsync(GlobalConfiguration.Admin_Role).GetAwaiter().GetResult())
                {
                  _roleManager.CreateAsync(new IdentityRole(GlobalConfiguration.Admin_Role)).GetAwaiter().GetResult();
                var user = new ApplicationUser()
                {
                    Email = "admin@gmail.com",
                    UserName="admin@gmail.com"
                };
                _userManager.CreateAsync(user, "Admin@12345").GetAwaiter().GetResult();
                _userManager.AddToRoleAsync(user, GlobalConfiguration.Admin_Role).GetAwaiter().GetResult();

                }
                return Task.CompletedTask;
           
        }
    }
}
