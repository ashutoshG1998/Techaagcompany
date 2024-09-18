using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechAgCompany.Entities
{
    public class Skill
    {
        public int Id { get; set; }
        public string Item { get; set; }
        public ICollection<StudentSkill> studentSkills { get; set; }=new List<StudentSkill>();
    }
}
