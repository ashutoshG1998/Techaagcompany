using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechAgCompany.Entities;

namespace TechAgCompany.Repository.Interfaces
{
    public interface IStateRepo
    {
        Task <IEnumerable<State>> GetAll();
        Task <State> GetById(int id);
        Task save(State state);
        Task Edit(State state);
        Task RemoveData(State state);
        //istate

    }
}
