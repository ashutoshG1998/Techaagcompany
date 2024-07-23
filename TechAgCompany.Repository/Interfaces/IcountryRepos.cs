using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechAgCompany.Entities;

namespace TechAgCompany.Repository.Interfaces
{
    public interface IcountryRepos
    {
        Task<IEnumerable<Country>> GetAll();
        
        Task<Country> GetById(int id);    

        Task save(Country country);
        Task Edit(Country country);
        Task RemoveData(Country country);
    }
}
