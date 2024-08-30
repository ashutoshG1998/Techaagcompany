namespace ConcertBooking.WebHost.ViewModel.HomePageViewModel
{
    public class HomeConcertDetailsViewmodel
    {
        public int ConcertId { get; set; }
        public string ConcertName { get; set; }
        public DateTime ConcerDateTime { get; set; }
        public string Descrpition { get; set; }
        public string ArtistName { get; set; }
        public string ArtistImage { get; set; }
        public string VenueName { get; set; }
        public string VenueAddress { get; set; }
        public string ConcertImage { get; set; }
    }
}
