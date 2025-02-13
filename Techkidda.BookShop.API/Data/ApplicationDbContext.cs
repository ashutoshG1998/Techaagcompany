
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Techkidda.BookShop.API.Entities;


public class ApplicationDbContext :IdentityDbContext
{ 
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
    {

    }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<Author> authors { get; set; }

    public DbSet<BookAuthor> booksAuthors { get; set; }  
    public DbSet<BookCategory> bookCategories {  get; set; }

    public DbSet<BookShop> bookShopAuthors { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<BookAuthor>().HasKey(x => new { x.BookId, x.AuthoreId });
        builder.Entity<BookCategory>().HasKey(x => new { x.BookId, x.CategoeyId });
        builder.Entity<BookShop>().HasKey(x => new { x.BookId, x.ShopId });



        base.OnModelCreating(builder);
    }

}
