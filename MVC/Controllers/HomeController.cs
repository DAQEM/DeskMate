using System.Diagnostics;
using BLL.Entities;
using DataFactory.Factories;
using Microsoft.AspNetCore.Mvc;
using MVC.Models;

namespace MVC.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ExampleFactory _exampleFactory;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
        _exampleFactory = new ExampleFactory();
    }

    public IActionResult Index()
    {
        List<ExampleEntity> exampleEntities = _exampleFactory.GetAll();
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