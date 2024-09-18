

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
    public DbSet<userInfo> userInfos { get; set; }

    public DbSet<Student> Students { get; set; }
    public DbSet<Skill> skills { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<StudentSkill>().HasKey(s => new { s.studentId, s.skillId });
        base.OnModelCreating(modelBuilder);
    }
}
