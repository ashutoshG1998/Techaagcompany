using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechAgCompany.Entities
{
    public class StudentSkill
    {
        public int studentId { get; set; }
        public Student student {  get; set; }
        public int skillId { get; set; }
        public Skill skill { get; set; }
    }
}
