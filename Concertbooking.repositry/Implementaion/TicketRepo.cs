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
           var bookedTickets  =await _context.ticket.Where(t=>t.ConcertId == Id && t.IsBooked).Select(t=>t.SeatNumber).ToListAsync();
            return bookedTickets;
        }
    }
}
