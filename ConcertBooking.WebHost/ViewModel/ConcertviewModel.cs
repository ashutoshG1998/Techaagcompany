using TechAsgCompany.Conertbooking.Entities;

namespace ConcertBooking.WebHost.ViewModel
{
    public class Concertviewmodel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateTime { get; set; }

        public string VenueName { get; set; }

        public string ArtistName { get; set; }

    }
}
