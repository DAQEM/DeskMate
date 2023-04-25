using BLL.Data.Auth;
using BLL.DTOs;
using BLL.Entities;
using Microsoft.AspNetCore.Mvc;
using MVC.Models.Auth;
using MVC.Models.Dashboard;

namespace MVC.Controllers;

public class AuthController : BaseController<AuthController>
{
    private readonly IAuthService _authService;

	public AuthController(IAuthService authService)
	{
        _authService = authService;
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
            return View(loginModel);
        }

        Employee employee = _authService.LoginEmployee(new Employee(email: loginModel.Email, hashedPassword: loginModel.Password));

        if (employee == null)
        {
            ModelState.AddModelError("Password", "Password incorrect.");
            return View(loginModel);
        }

        return RedirectToAction("Index", "Home");
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
	    {
            return View(registerModel);
	    }

        bool isEmailTaken = _authService.RegisterEmployeeIfNotTaken(RegisterModelToUserDto(registerModel));

        if (isEmailTaken)
        {
            ModelState.AddModelError("Email", "Email is already taken");
	        return View(registerModel);
        }

        return RedirectToAction("Index", "Home");
    }

    public UserDTO RegisterModelToUserDto(RegisterModel registerModel)
    {
        return new UserDTO()
        {
			Name = registerModel.Username,
			Email = registerModel.Email,
			Password = registerModel.Password
		};
    }
}