using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechAgCompany.Entities;

namespace TechAgCompany.Repository.Interfaces
{
    public interface IstudentRepo
    {
        Task<IEnumerable<Student>> GetAll();
        Task<Student> GetById(int id);
        Task save(Student student);
        Task Edit(Student student);
        Task RemoveData(Student student);
    }
}
