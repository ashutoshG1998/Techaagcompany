using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechAgCompany.Entities;

namespace TechAgCompany.Repository.Interfaces
{
    public interface ISkillRepo
    {
        Task<IEnumerable<Skill>> GetAll();
        Task<Skill> GetById(int id);
        Task save(Skill Skill);
        Task Edit(Skill Skill);
        Task RemoveData(Skill Skill);
    }
}
