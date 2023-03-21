using Microsoft.AspNetCore.Mvc;
using MVC.Models.Auth;

namespace MVC.Controllers;

public class AuthController : BaseController<AuthController>
{
    
    public AuthController(ILogger<AuthController> logger) : base(logger)
    {
    }
    
    [HttpGet]
    [Route("login")]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    [Route("login")]
    public IActionResult Login(LoginModel loginModel)
    {
        if (!ModelState.IsValid)
        {
            //TODO: login
            return RedirectToAction("Index", "Home");
        }

        return View();
    }

    [HttpGet]
    [Route("logout")]
    public IActionResult Logout()
    {
        //TODO: logout
        return RedirectToAction("Index", "Home");
    }

    [HttpGet]
    [Route("register")]
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    [Route("register")]
    public IActionResult Register(RegisterModel registerModel)
    {
        if (!ModelState.IsValid)
            //TODO: register
            return RedirectToAction("Index", "Home");
        {
            return View();
        }
    }
}