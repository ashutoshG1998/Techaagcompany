using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechAgCompany.Entities;

namespace TechAgCompany.Repository.Interfaces
{
    public interface IUserinfo
    {
        Task Registeruser(userInfo userinfo);

       Task<userInfo> Getuserinfo(string username,string password);
    }
}
