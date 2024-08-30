namespace ConcertBooking.WebHost.ViewModel.HomePageViewModel
{
    public class AvailabelTicketviewmodel
    {
        public int ConcertId {  get; set; }
        public string ConcertName {  get; set; }
        public List<int> AvailableSeats { get; set; }
    }
}
