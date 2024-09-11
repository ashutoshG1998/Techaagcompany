using Concertbooking.repositry.Interfaces;
using Conertbooking.Entities;
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
    }
}
