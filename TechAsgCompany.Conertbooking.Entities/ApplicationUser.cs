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
//UserManger :Store user data in database,get user information from database
//claims:Piece of information about user,Addhar card
//ClaimsIdentity =List<Claim>

namespace Conertbooking.Entities
{
    public class ApplicationUser:IdentityUser
    {
        public string? FirstName { get; set; }
        public string? Address { get; set; }
        public string? Pincode {  get; set; }
    }
}
