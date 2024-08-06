using Concertbooking.repositry.Interfaces;
using Microsoft.EntityFrameworkCore;
using TechAsgCompany.Conertbooking.Entities;
using TechAsgCompany.Conertbooking.repository;

namespace Concertbooking.repositry.Implementaion
{
    public class Artistrepo : IArtistRepo
    {
        private readonly ApplicationDbContext _context;

        public Artistrepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Edit(Artist artist)
        {
            _context.artists.Update(artist);
            await _context.SaveChangesAsync();
            
        }

        public async Task<IEnumerable<Artist>> getAll()
        {
           return await _context.artists.ToListAsync();
        }

        public async Task<Artist> GetById(int id)
        {
            return await _context.artists.FirstOrDefaultAsync(x => x.Id == id);
            
        }

        public async Task RemoveData(Artist artist)
        {
            _context.artists.Remove(artist);
            await _context.SaveChangesAsync();

        }

        public async Task Save(Artist artist)
        { 
           await _context.artists.AddAsync(artist);
            await _context.SaveChangesAsync();
        
        }
    }
}
