using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechAsgCompany.Conertbooking.Entities
{
    
    public class Artist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Bio { get; set; }
        public string ImageUrl { get; set; }

       public ICollection<concert> concerts { get; set; }=new List<concert>();

    }
}
