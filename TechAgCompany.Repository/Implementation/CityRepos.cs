using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechAgCompany.Entities;
using TechAgCompany.Repository.Interfaces;

namespace TechAgCompany.Repository.Implementation
{
    public class CityRepos : ICityRepos
    {
        private readonly ApplicationDbContext _context;

        public CityRepos(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Edit(City city)
        {
          _context.citys.Update(city);
          _context.SaveChanges();
        }

        public IEnumerable<City> GetAll()
        {
            var city=_context.citys.Include(x=>x.StateName).ThenInclude(y=>y.CountryName).ToList();
            return city ;
        }

        public City GetById(int id)
        {
            var city=_context.citys.Find(id);
            return city;
        }

        public void RemoveData(City city)
        {
           _context.citys.Remove(city);
            _context.SaveChanges();
        }

        public void save(City city)
        {
           _context.citys.Add(city);
            _context.SaveChanges();
        }
    }
}
