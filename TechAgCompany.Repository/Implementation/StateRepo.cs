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

        public void Edit(State state)
        {
            _context.states.Update(state);
            _context.SaveChanges();
            
        }

        public IEnumerable<State> GetAll()
        {
            var state = _context.states.Include(x=>x.CountryName).ToList();
            return state;
            
        }

       public State GetById(int id)
        {
            var state = _context.states.Find(id);
            return state;
        }

        public void RemoveData(State state)
        {
             _context.states.Remove(state);
            _context.SaveChanges();
        }

        public void save(State state)
        {
            _context.states.Add(state);
            _context.SaveChanges();
        }

    }
}
