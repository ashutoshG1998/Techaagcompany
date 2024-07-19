
using Microsoft.EntityFrameworkCore;
using Techaagcompany.web.Models;

public class ApplicationDbContext :DbContext
{ 
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
    {

    }
    public DbSet<People> People { get; set; }
}
