using BLL.Data;
using BLL.Data.Employee;
using BLL.Data.Floor;
using DAL;
using DAL.Repositories;
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

app.UseAuthorization();

app.MapControllerRoute(
    "default",
    "{controller=Home}/{action=Index}/{id?}");

app.Run();