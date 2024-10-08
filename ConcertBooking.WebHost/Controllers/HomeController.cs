﻿using Concertbooking.repositry.Interfaces;
using ConcertBooking.WebHost.Models;
using ConcertBooking.WebHost.ViewModel.HomePageViewModel;
using Conertbooking.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;

namespace ConcertBooking.WebHost.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConcertRepo _concertRepo;
        private readonly ITicketRepo _ticketRepo;
        private readonly IbookingRepo _bookingRepo;

        public HomeController(ILogger<HomeController> logger, IConcertRepo concertRepo, ITicketRepo ticketRepo, IbookingRepo bookingRepo)
        {
            _logger = logger;
            _concertRepo = concertRepo;
            _ticketRepo = ticketRepo;
            _bookingRepo = bookingRepo;
        }

        public  async Task<IActionResult> Index()
        {
            DateTime Todat = DateTime.Today;
            var concerts = await _concertRepo.getAll();
            var vm = concerts.Where(x => x.DateTime.Date >= Todat).Select(x => new HomeConcertViewModel
            {
                ConcertId = x.Id,
                ConcertName = x.Name,
                ArtistName = x.Artist.Name,
                ConcertImage = x.Imageurl,
                Descrpition = x.Description.Length > 100 ? x.Description.Substring(0, 100) : x.Description,
            }).ToList();
            return View(vm);
        }

        public async Task<IActionResult> Details(int id)
        {
            var concert= await _concertRepo.GetById(id);
            if (concert == null)
            {
                return NotFound();
            }
            var vm = new HomeConcertDetailsViewmodel
            {
                ConcertId = concert.Id,
                ConcertName = concert.Name,
                Descrpition = concert.Description,
                ArtistName = concert.Artist.Name,
                ConcerDateTime=concert.DateTime,
                ArtistImage=concert.Artist.ImageUrl,
                VenueName = concert.Venue.Name,
                VenueAddress = concert.Venue.Address,
                ConcertImage=concert.Imageurl,
             
            };
            return View(vm);
        }


        [Authorize]
        public async Task<IActionResult> AvailabelTickets(int id)
        {
            var concert =  await _concertRepo.GetById(id);
            if (concert == null)
            { 
                return NotFound();
            }
            var allSeats = Enumerable.Range(1, concert.Venue.seatCapacity).ToList();
            var bookTickets = await _ticketRepo.GetBookedTicket(concert.Id);
            var AvailabelSeats=allSeats.Except(bookTickets).ToList();
            var Viewmodel = new AvailabelTicketviewmodel
            {
                ConcertId = concert.Id,
                ConcertName = concert.Name,
                AvailableSeats = AvailabelSeats
            };
            return View(Viewmodel);            
        }
        public async Task<IActionResult> BookTickets(int ConcertId, List<int> selectedSeats)
        {
            if (selectedSeats == null || selectedSeats.Count == 0)
            {
                ModelState.AddModelError("", "No Seats Selected");
                return RedirectToAction("AvailabelTickets", new { id = ConcertId });
            }
            var claimsidentity = (ClaimsIdentity)User.Identity;
            var claim = claimsidentity.FindFirst(ClaimTypes.NameIdentifier);
            var userId = claim.Value;

            var Newbooking = new Booking
            {
                ConcertId = ConcertId,
                DateTime = DateTime.Now,
                UserId = userId,
            };
            foreach (var Seatnumbere in selectedSeats)
            {
                Newbooking.Tickets.Add(new Ticket
                {
                    SeatNumber = Seatnumbere,
                    IsBooked = true,
                });

            }
           await _bookingRepo.AddBooking(Newbooking);
            return RedirectToAction("Index");
        }
            

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
