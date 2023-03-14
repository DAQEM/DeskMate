using BLL.Data.Example;
using DAL.Repositories;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

IServiceCollection services = builder.Services;
services.AddControllersWithViews();

services.AddScoped<IExampleRepository, ExampleRepository>();
services.AddScoped<IExampleService, ExampleService>();

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