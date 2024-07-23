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
    public class CountryRepo : IcountryRepos
    {

        public readonly ApplicationDbContext _Context;

        public CountryRepo(ApplicationDbContext context)
        {
            _Context = context;
        }

        public async Task Edit(Country country)
        {
            _Context.countries.Update(country);
           await _Context.SaveChangesAsync();
        }

        public  async Task<IEnumerable<Country>> GetAll()
        {
            var countries = await _Context.countries.ToListAsync();
            return countries;
        }

        public async Task <Country> GetById(int id)
        {
            
           return await _Context.countries.FindAsync(id);

        }

        public async Task RemoveData(Country country)
        {
           _Context.countries.Remove(country);
            await _Context.SaveChangesAsync();
        }

        public async Task save(Country country)
        {
           _Context.countries.Add(country);
            await _Context.SaveChangesAsync();
        }
    }
}
