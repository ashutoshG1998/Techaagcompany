using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechAgCompany.Entities
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; } = "Default Country";

        public int StateId { get; set; }

        public State StateName { get; set; }

        



    }
}
