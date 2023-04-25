using System.Diagnostics;
using System.Security.Claims;
using BLL.Data.Auth;
using BLL.DTOs;
using BLL.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
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
    public async Task<IActionResult> Login(LoginModel loginModel)
    {
        if (!ModelState.IsValid)
        {
            return View(loginModel);
        }

        Employee? employee =
            _authService.LoginEmployee(new Employee(email: loginModel.Email, hashedPassword: loginModel.Password));

        if (employee == null)
        {
            Console.WriteLine("Employee is null");
            ModelState.AddModelError("Password", "Password incorrect.");
            return View(loginModel);
        }

        List<Claim> claim = new()
        {
            new Claim(ClaimTypes.Name, employee.Id.ToString())
        };

        ClaimsIdentity identity = new(claim, CookieAuthenticationDefaults.AuthenticationScheme);


        await HttpContext.SignInAsync(
            CookieAuthenticationDefaults.AuthenticationScheme,
            new ClaimsPrincipal(identity),
            new AuthenticationProperties
            {
                IsPersistent = loginModel.RememberMe,
            });

        return RedirectToAction("Index", "Home");
    }

    [HttpGet]
    [Route("logout")]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

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

        bool isEmailTaken = _authService.RegisterEmployeeIfNotTaken(RegisterModelToUserDto(registerModel).ToEmployee());

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