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

        public async Task Edit(City city)
        {
          _context.citys.Update(city);
          await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<City>> GetAll()
        {
            var city=await _context.citys.Include(x=>x.StateName).ThenInclude(y=>y.CountryName).ToListAsync();
            return city ;
        }

        public async Task<City> GetById(int id)
        {
            var city= await _context.citys.FindAsync(id);
            return city;
        }

        public async Task RemoveData(City city)
        {
           _context.citys.Remove(city);
           await _context.SaveChangesAsync();
        }

        public async Task save(City city)
        {
          await _context.citys.AddAsync(city);
           await _context.SaveChangesAsync();
        }
    }
}
