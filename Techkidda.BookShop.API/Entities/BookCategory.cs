namespace Techkidda.BookShop.API.Entities
{
    public class BookCategory
    {
        public int BookId { get; set; }
        public int CategoeyId {  get; set; }
        public int CategoryName { get; set; }

        public Book Book { get; set; }
        public Category Category { get; set; }

    }
}
