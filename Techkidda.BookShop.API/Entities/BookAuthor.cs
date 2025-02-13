namespace Techkidda.BookShop.API.Entities
{
    public class BookAuthor
    {
        public int AuthoreId {  get; set; }
        public int BookId {  get; set; }

        public Book book { get; set; }
        public Author Author { get; set; }


        public int order {  get; set; }
    }
}
