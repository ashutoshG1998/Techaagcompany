using Microsoft.EntityFrameworkCore;
using TechAgCompany.Entities;
using TechAgCompany.Repository.Implementation;
using TechAgCompany.Repository.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("TechAgCompany.UI")));
//Di :Tightly coupling ---Conver  --loosly coupled
//DI -Achieve IOC(iNVERSALE OF CONTROL)
builder.Services.AddScoped<IcountryRepos, CountryRepo>();
builder.Services.AddScoped<IStateRepo, StateRepo>();
builder.Services.AddScoped<ICityRepos, CityRepos>();
builder.Services.AddScoped<IUserinfo, Userinfo>();
builder.Services.AddSingleton<IHttpContextAccessor,HttpContextAccessor>();
builder.Services.AddSession(option =>
{
    option.IdleTimeout= TimeSpan.FromMinutes(10);
    option.Cookie.HttpOnly=true;
}

);

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
app.UseSession();
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
