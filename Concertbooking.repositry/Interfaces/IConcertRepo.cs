using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechAsgCompany.Conertbooking.Entities;

namespace Concertbooking.repositry.Interfaces
{
    public interface IConcertRepo
    {
        Task<IEnumerable<concert>> getAll();
        Task<concert> GetById(int id);
        Task Save(concert concert);
        Task Edit(concert concert);

        Task RemoveData(concert concert);
    }
}
