using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Identity : Membership Programe : Authentication-Credentials(username and password)
//and authorization(Access Rights)
//Registe : IdentityUser Class - Id(Guid) ,username,Password,Email,Phone
//SignInManager -Check user signin, User Signin

namespace Conertbooking.Entities
{
    public class ApplicationUser:IdentityUser
    {
        public string? FirstName { get; set; }
        public string? Address { get; set; }
        public string? Pincode {  get; set; }
    }
}
