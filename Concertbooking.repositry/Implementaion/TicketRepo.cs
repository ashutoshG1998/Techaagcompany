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
    public class TicketRepo : ITicketRepo
    {
        private readonly ApplicationDbContext _context;

        public TicketRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<int>> GetBookedTicket(int Id)
        {
           var bookedTickets  =await _context.ticket.Include(y=>y.booking).Where(t=>t.booking.ConcertId == Id && t.IsBooked).Select(t=>t.SeatNumber).ToListAsync();
            return bookedTickets;
        }

        public async Task<IEnumerable<Booking>> GetBookings(string UserId)
        {
           var bookings=await _context.Bookings.Where(X=>X.UserId == UserId).Include(Y=>Y.Tickets).Include(z=>z.concert).ToListAsync();
            return bookings;   
        }
    }
}
