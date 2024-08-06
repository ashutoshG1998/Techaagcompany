using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechAsgCompany.Conertbooking.Entities
{   
    //venuers -----------------(*)Concert
    //artist- -----------------(*) Concert
    public class concert
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Imageurl { get; set; }
        public DateTime DateTime { get; set; }

       
        public int VenueId {  get; set; }
        public Venue Venue { get; set; }
        public int ArtistId { get; set; }
        public Artist Artist { get; set; }
    }
}
