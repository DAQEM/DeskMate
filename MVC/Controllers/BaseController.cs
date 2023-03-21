using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers;

public class BaseController<T> : Controller where T : Controller
{
    private readonly ILogger<T> _logger;
    
    public BaseController(ILogger<T> logger)
    {
        _logger = logger;
    }
}