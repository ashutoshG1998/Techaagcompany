using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechAsgCompany.Conertbooking.Entities;

namespace Conertbooking.Entities
{
    public class Booking
    {
        public int BookingId { get; set; }
        public DateTime DateTime { get; set; }
        public int ConcertId { get; set; }
        public concert concert { get; set; }
        public string UserId {  get; set; }
        public ICollection<Ticket> Tickets {  get; set; }=new List<Ticket>();
    }
}
