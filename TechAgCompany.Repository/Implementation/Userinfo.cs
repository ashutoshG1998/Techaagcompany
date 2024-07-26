using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechAgCompany.Entities;
using TechAgCompany.Repository.Interfaces;

namespace TechAgCompany.Repository.Implementation
{
    public class Userinfo : IUserinfo
    {
        private readonly ApplicationDbContext _context;

        public Userinfo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<userInfo> Getuserinfo(string username, string password)
        {
            var user=await _context.userInfos.FirstOrDefaultAsync(x=>x.UserName.ToLower()==username.ToLower()&&x.Password==password);
            return user;
        }

        public async Task Registeruser(userInfo userinfo)
        {
            if(!Exists(userinfo.UserName))
           await _context.userInfos.AddAsync(userinfo);
               await _context.SaveChangesAsync();
        }

        private bool Exists(string username)
        {
            return _context.userInfos.Any(x=>x.UserName.ToLower()==username.ToLower());
        }
    }
}
