namespace ConcertBooking.WebHost.ViewModel
{
    public class EditArtistViewModel
    {
        public int Id {  get; set; }
        public string Name { get; set; }
        public string Bio { get; set; }
        public string ImageUrl { get; set; }
        public IFormFile ChooseImageUrl { get; set; }
    }
}
