using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechAgCompany.Entities;
using TechAgCompany.Repository.Interfaces;

namespace TechAgCompany.Repository.Implementation
{
    public class CountryRepo : IcountryRepos
    {

        public readonly ApplicationDbContext _Context;

        public CountryRepo(ApplicationDbContext context)
        {
            _Context = context;
        }

        public void Edit(Country country)
        {
            _Context.countries.Update(country);
            _Context.SaveChanges();
        }

        public IEnumerable<Country> GetAll()
        {
            return _Context.countries.ToList();
        }

        public Country GetById(int id)
        {
            
           return _Context.countries.Find(id);

        }

        public void RemoveData(Country country)
        {
           _Context.countries.Remove(country);
            _Context.SaveChanges();
        }

        public void save(Country country)
        {
           _Context.countries.Add(country);
            _Context.SaveChanges();
        }
    }
}
