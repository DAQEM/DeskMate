using BLL.Data.Employee;
using BLL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVC.Models.Dashboard;

namespace MVC.Controllers;

[Authorize]
[Route("dashboard")]
public class DashboardController : BaseController<DashboardController>
{
    private readonly IEmployeeService _employeeService;

    public DashboardController(IEmployeeService employeeService)
    {
        _employeeService = employeeService;
    }

    [HttpGet]
    [Route("")]
    public ActionResult Index()
    {
        return View(new RegisterModel());
    }

    [HttpGet]
    [Route("details/{id}")]
    public ActionResult Details(Guid id)
    {
        Employee employee = _employeeService.GetEmployeeById(id);

        return View(employee);
    }

    [HttpPost("create")]
    [ValidateAntiForgeryToken]
    public ActionResult Create(RegisterModel model)
    {
        if (!ModelState.IsValid)
        {
            return View("Index", model);
        }

        Employee? employee = _employeeService.CreateEmployee(new Employee(
            name: model.Username,
            email: model.Email,
            hashedPassword: model.Password
        ));

        if (employee == null)
        {
            ModelState.AddModelError("Username", "An error occurred while creating the user");
            return View("Index", model);
        }
        return RedirectToAction(nameof(Details), new { id = employee.Id });
    }
}