using System.Diagnostics;
using BLL.Data.Example;
using BLL.Entities;
using Microsoft.AspNetCore.Mvc;
using MVC.Models;

namespace MVC.Controllers;

public class HomeController : BaseController<HomeController>
{
    private readonly IExampleService _exampleService;

    public HomeController(ILogger<HomeController> logger, IExampleService exampleService) : base(logger)
    {
        _exampleService = exampleService;
    }

    public IActionResult Index()
    {
        List<ExampleEntity> exampleEntities = _exampleService.GetAll();
        foreach (ExampleEntity exampleEntity in exampleEntities)
        {
            Console.WriteLine(exampleEntity.Id);
        }
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}