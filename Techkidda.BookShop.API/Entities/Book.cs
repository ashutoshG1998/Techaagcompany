using System.ComponentModel.DataAnnotations;

namespace Techkidda.BookShop.API.Entities
{
    public class Book
    {
        public int Id { get; set; }

        [StringLength(maximumLength:80)]
        public required string Title { get; set; }

        public string Summary {  get; set; }
        public string Cover {  get; set; }

        public bool IsAvailabel { get; set; }
        public DateTime PublishedDate {  get; set; }
        public List<BookAuthor> BookAuthors { get; set; }
        public List<BookCategory> BookCategories { get; set; }
        public List<BookShop> BookShops { get; set; }


    }
}
