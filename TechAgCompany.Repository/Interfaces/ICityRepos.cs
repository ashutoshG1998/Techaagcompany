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
        IEnumerable<City> GetAll();
        City GetById(int id);

        void save(City city);
        void Edit(City city);
        void RemoveData(City city);
    }
}
