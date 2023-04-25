using BLL.Data;
using BLL.Data.Auth;
using BLL.Data.Employee;
using BLL.Data.Employee.Reservation;
using BLL.Data.Floor;
using DAL;
using DAL.Repositories;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

IServiceCollection services = builder.Services;
services.AddControllersWithViews().AddRazorRuntimeCompilation();


IConfigurationRoot config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();

builder.Services.AddDbContext<DeskMateContext>(
    options =>
    {
        options.UseMySql(config.GetConnectionString("MySqlConnection"),
            ServerVersion.AutoDetect(config.GetConnectionString("MySqlConnection")));
    }, ServiceLifetime.Transient);

services.AddScoped<IWorkspaceRepository, WorkspaceRepository>();
services.AddScoped<IWorkspaceService, WorkspaceService>();

services.AddScoped<ICharacteristicRepository, CharacteristicRepository>();
services.AddScoped<ICharacteristicService, CharacteristicService>();

services.AddScoped<IEmployeeRepository, EmployeeRepository>();
services.AddScoped<IEmployeeService, EmployeeService>();

services.AddScoped<ILocationRepository, LocationRepository>();
services.AddScoped<ILocationService, LocationService>();

services.AddScoped<IFloorRepository, FloorRepository>();
services.AddScoped<IFloorService, FloorService>();

services.AddScoped<IReservationRepository, ReservationRepository>();
services.AddScoped<IReservationService, ReservationService>();

services.AddScoped<IAuthRepository, AuthRepository>();
services.AddScoped<IAuthService, AuthService>();


services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
   .AddCookie(options =>
   {
       options.Cookie.Name = "EmployeeId";
       options.Cookie.SameSite = SameSiteMode.Strict;
       options.Cookie.HttpOnly = true;
       options.ExpireTimeSpan = TimeSpan.FromMinutes(30);

       options.LoginPath = "/login";
       options.LogoutPath = "/logout";
   });

services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
    options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
    options.Cookie.SameSite = SameSiteMode.Strict;
});

WebApplication app = builder.Build();

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

app.UseSession();
app.UseAuthorization();
app.UseAuthentication();

app.MapControllerRoute(
    "default",
    "{controller=Home}/{action=Index}/{id?}");

app.Run();