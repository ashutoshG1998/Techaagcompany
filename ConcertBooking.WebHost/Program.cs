using Concertbooking.repositry.Implementaion;
using Concertbooking.repositry.Interfaces;
using Microsoft.EntityFrameworkCore;
using TechAgCompany.Concertbooking.repositry;
using TechAgCompany.Repository.Interfaces;
using TechAsgCompany.Conertbooking.repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("ConcertBooking.WebHost")));
builder.Services.AddScoped<IVenveRepo, VenueRepo>();
builder.Services.AddScoped<IConcertRepo, ConcertRepo>();
builder.Services.AddScoped<IArtistRepo, Artistrepo>();
builder.Services.AddScoped<IutilityRepo, UtilityRepo>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();






var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();