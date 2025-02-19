namespace Techkidda.BookShop.API.DTOs
{
    public class PaginationDto
    {
        public int page { get; set; } = 1;
        private int recordPerPage = 10;
        private readonly int maxAmount = 50;
        public int RecordPerPage
        {
            get { return recordPerPage; }
            set
            {
                recordPerPage = (value > maxAmount) ? maxAmount : value;
            }
        }
    }

}