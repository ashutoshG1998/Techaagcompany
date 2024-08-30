﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechAsgCompany.Conertbooking.Entities;

namespace Conertbooking.Entities
{
    public class Ticket
    {
        public int TicketId { get; set; }
        public int SeatNumber { get; set; }
        public bool IsBooked { get; set; }
        public int ConcertId { get; set; }

        public concert concert { get; set; }

        public int? BookingId {  get; set; }
        public Booking booking { get; set; }

    }
}
