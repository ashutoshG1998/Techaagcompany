using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechAgCompany.Entities
{
    public class State
    {
        public int Id { get; set; }     
        public string Name { get; set; } = "Default State";

        public int CountryId { get; set; }  //By default Foreign Key

        //Navigation property
        public Country? CountryName { get; set; }
        //Navigation property

        public ICollection<City> Citys { get; set; }= new HashSet<City>();
    }
}
