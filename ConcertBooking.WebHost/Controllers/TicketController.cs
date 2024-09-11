using Concertbooking.repositry.Interfaces;
using ConcertBooking.WebHost.ViewModel.TicketViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ConcertBooking.WebHost.Controllers
{
    public class TicketController : Controller
    {
        private ITicketRepo _Ticketrepo;
        public async  Task<IActionResult> MyTicket()
        {
            var claimsidentity = (ClaimsIdentity)User.Identity;
            var claim = claimsidentity.FindFirst(ClaimTypes.NameIdentifier);
            var userId = claim.Value;
            var bookings = await _Ticketrepo.GetBookings(userId);
            List<BookingViewModel> vm = new List<BookingViewModel>();
          foreach(var booking in bookings)
            {
                vm.Add(new BookingViewModel {BookingId=booking.BookingId,BookingDate=booking.DateTime,ConcertName=booking.concert.Name,Tickets=booking.Tickets.Select(Ticketvm=>new TicketViewModel
                {
                    SeatNumber=Ticketvm.SeatNumber

                }).ToList()
                
                });
            }
            return View(vm);
           }
    }
}
