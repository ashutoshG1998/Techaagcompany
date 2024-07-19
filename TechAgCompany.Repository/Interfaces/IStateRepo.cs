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
        IEnumerable<State> GetAll();
        State GetById(int id);

        void save(State state);
        void Edit(State state);
        void RemoveData(State state);

        void RemoveData(State state);
        void RemoveData(State state);

    }
}
