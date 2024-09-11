namespace ConcertBooking.WebHost.ViewModel.TicketViewModel
{
    public class BookingViewModel
    {

        public int BookingId { get; set; }
        public DateTime BookingDate { get; set; }

        public string ConcertName {  get; set; }
        public int Seatnumber {  get; set; }
        public List<TicketViewModel> Tickets { get; set; } = new List<TicketViewModel>();
    }
}
