using Conertbooking.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concertbooking.repositry.Interfaces
{
    public interface ITicketRepo
    {
        Task<IEnumerable<int>> GetBookedTicket(int concertId);

    }
}
