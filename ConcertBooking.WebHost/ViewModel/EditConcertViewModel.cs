namespace ConcertBooking.WebHost.ViewModel
{
    public class EditConcertViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IFormFile ChooseImage { get; set; }

        public string Imageurl {  get; set; }
        public DateTime DateTime { get; set; }
        public int VenueId { get; set; }
        public int ArtistId { get; set; }
    }
}
