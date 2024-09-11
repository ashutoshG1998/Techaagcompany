using Concertbooking.repositry.Implementaion;
using Concertbooking.repositry.Interfaces;
using Microsoft.EntityFrameworkCore;
using TechAgCompany.Concertbooking.repositry;
using TechAgCompany.Repository.Interfaces;
using TechAsgCompany.Conertbooking.repository;
using Microsoft.AspNetCore.Identity;
using Conertbooking.Entities;
using Microsoft.AspNetCore.Identity.UI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("ConcertBooking.WebHost")));

builder.Services.AddIdentity<ApplicationUser,IdentityRole>(/*options => options.SignIn.RequireConfirmedAccount = true*/)
    .AddDefaultTokenProviders().AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.ConfigureApplicationCookie(Options =>
{
    Options.LoginPath = "/Identity/Account/Login";
    Options.LogoutPath= "/Identity/Account/Logout";
    Options.AccessDeniedPath = "/Identity/Account/AccessDenied";


});

builder.Services.AddScoped<IDbinitial, Dbinitial>();
builder.Services.AddScoped<IVenveRepo, VenueRepo>();
builder.Services.AddScoped<IConcertRepo, ConcertRepo>();
builder.Services.AddScoped<IArtistRepo, Artistrepo>();
builder.Services.AddScoped<IutilityRepo, UtilityRepo>();
builder.Services.AddScoped<ITicketRepo,TicketRepo>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped<IEmailSender,EmailSender>();
builder.Services.AddRazorPages();





var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


DataSeeding();

void DataSeeding()
{
    using(var scope = app.Services.CreateScope())
    {
        var _dpRepo = scope.ServiceProvider.GetRequiredService<IDbinitial>();
        _dpRepo.seed();
    }
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();
app.Run();
