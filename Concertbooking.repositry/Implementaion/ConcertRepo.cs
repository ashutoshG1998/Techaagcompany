using Concertbooking.repositry.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechAsgCompany.Conertbooking.Entities;
using TechAsgCompany.Conertbooking.repository;

namespace Concertbooking.repositry.Implementaion
{
    public class ConcertRepo : IConcertRepo
    {
        private readonly ApplicationDbContext _context;

        public ConcertRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Edit(concert concert)
        {
            _context.Update(concert);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<concert>> getAll()
        {
           return await _context.concerts.Include(x => x.Venue).Include(x => x.Artist).ToListAsync();
        }

        public async Task<concert> GetById(int id)
        {
           return await _context.concerts.FirstOrDefaultAsync(x=>x.Id==id);
        }

        public async Task RemoveData(concert concert)
        {
            _context.concerts.Remove(concert);
           await _context.SaveChangesAsync();
        }

        public async Task Save(concert concert)
        {
            await _context.concerts.AddAsync(concert);
            await _context.SaveChangesAsync();
        }
    }
}
