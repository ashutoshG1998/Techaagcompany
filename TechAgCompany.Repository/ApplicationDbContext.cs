

using Microsoft.EntityFrameworkCore;
using TechAgCompany.Entities;

public class ApplicationDbContext :DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }
    public DbSet<Country> countries { get; set; }
    public DbSet<State> states { get; set; }
    public DbSet<City> citys { get; set; }
}
