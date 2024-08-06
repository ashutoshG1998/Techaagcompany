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
    public class VenueRepo : IVenveRepo
    { 
      private readonly ApplicationDbContext _context;

        public VenueRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Edit(Venue venue)
        {
            _context.Update(venue);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Venue>> GetAll()
        {
            return await _context.venues.ToListAsync();
        }

        public async Task<Venue> GetById(int id)
        {

            return await _context.venues.FirstOrDefaultAsync(x=>x.Id ==id);
        }

       
        public async Task RemoveData(Venue venue)
        {
            _context.venues.Remove(venue);
            await _context.SaveChangesAsync();
        }

        public async Task Save(Venue venue)
        {
            await _context.venues.AddAsync(venue);
            await _context.SaveChangesAsync();
        }
    }
}
