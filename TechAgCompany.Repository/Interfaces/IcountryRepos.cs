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
        IEnumerable<Country> GetAll();
        Country GetById(int id);    

        void save(Country country);
        void Edit(Country country);
        void RemoveData(Country country);
    }
}
