using Conertbooking.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concertbooking.repositry.Interfaces
{
    public interface IbookingRepo
    {

        Task AddBooking(Booking booking);
    }
}
