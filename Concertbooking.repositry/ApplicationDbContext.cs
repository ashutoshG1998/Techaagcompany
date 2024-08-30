
using Conertbooking.Entities;
using Microsoft.EntityFrameworkCore;
using TechAsgCompany.Conertbooking.Entities;

namespace TechAsgCompany.Conertbooking.repository
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Venue> venues { get; set; }
        public DbSet<concert> concerts { get; set; }
        public DbSet<Artist> artists { get; set; }
        //  public DbSet<userInfo> userInfos { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Ticket> ticket { get; set; }
    }
}