using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechAgCompany.Entities;

namespace TechAgCompany.Repository.Interfaces
{
    public interface ICityRepos
    {
        Task <IEnumerable<City>> GetAll();
        Task<City> GetById(int id);

        Task save(City city);
        Task Edit(City city);
        Task RemoveData(City city);
    }
}
