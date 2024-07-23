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
    public class StateRepo : IStateRepo
    {
        private readonly ApplicationDbContext _context;

        public StateRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Edit(State state)
        {
             _context.states.Update(state);
           await _context.SaveChangesAsync();
            
        }

        public async Task<IEnumerable<State>> GetAll()
        {
            var state = await _context.states.Include(x => x.CountryName).ToListAsync();
            return state;
            
        }

       public async Task<State> GetById(int id)
        {
            var state =await _context.states.FindAsync(id);
            return state;
        }

        public async Task RemoveData(State state)
        {
             _context.states.Remove(state);
           await _context.SaveChangesAsync();
        }

        public async Task save(State state)
        {
             await _context.states.AddAsync(state);
            await _context.SaveChangesAsync();
        }

    }
}
