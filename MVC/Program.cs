using BLL.Data;
using BLL.Data.Employee;
using DAL.Repositories;
using Microsoft.EntityFrameworkCore;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

IServiceCollection services = builder.Services;
services.AddControllersWithViews().AddRazorRuntimeCompilation();


IConfigurationRoot config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();

builder.Services.AddDbContext<DAL.DeskMateContext>(
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
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();