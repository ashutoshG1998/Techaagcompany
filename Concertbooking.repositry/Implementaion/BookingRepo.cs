using Concertbooking.repositry.Interfaces;
using Conertbooking.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechAsgCompany.Conertbooking.repository;

namespace Concertbooking.repositry.Implementaion
{
    public class BookingRepo : IbookingRepo
    {
        private readonly ApplicationDbContext _context;

        public BookingRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddBooking(Booking booking)
        {
            await _context.Bookings.AddAsync(booking);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Booking>> GetAll(int ConcerId)
        {
            var booking = await _context.Bookings.Include(b => b.Tickets)
                .Include(d=>d.concert)
                .Include(c => c.User).Where(a => a.ConcertId == ConcerId).ToListAsync();
                return booking;
        }
    }
}
