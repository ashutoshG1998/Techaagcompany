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
    public class SkillRepo : ISkillRepo
    {
        private ApplicationDbContext _context;

        public SkillRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Edit(Skill Skill)
        {
            _context.Update(Skill);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Skill>> GetAll()
        {
           return await _context.skills.ToListAsync();
        }

        public async Task<Skill> GetById(int id)
        {
            return await _context.skills.FindAsync(id);
        }

        public async Task RemoveData(Skill Skill)
        {
             _context.skills.Remove(Skill);
            _context.SaveChanges();
        }

        public async Task save(Skill Skill)
        {
            await _context.skills.AddAsync(Skill);
            await _context.SaveChangesAsync();
        }
    }
}
