using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechAsgCompany.Conertbooking.Entities;

namespace Concertbooking.repositry.Interfaces
{
    public interface IArtistRepo
    {
        Task<IEnumerable<Artist>> getAll();
        Task<Artist> GetById(int id);
        Task Save(Artist artist);
        Task Edit(Artist artist);
        Task RemoveData(Artist artist);
    }
}
