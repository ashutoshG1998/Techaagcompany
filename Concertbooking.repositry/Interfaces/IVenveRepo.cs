using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechAsgCompany.Conertbooking.Entities;

namespace Concertbooking.repositry.Interfaces
{
    public interface IVenveRepo
    {
        public Task<IEnumerable<Venue>> GetAll();
        public Task<Venue> GetById(int id);

        Task Save(Venue venue);
        Task Edit(Venue venue);
        Task RemoveData(Venue venue);
    }
}
