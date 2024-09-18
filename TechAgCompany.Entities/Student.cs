using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechAgCompany.Entities
{
    public class Student
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<StudentSkill> studentSkills { get; set; } = new List<StudentSkill>();

    }
}
