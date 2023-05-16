using BLL.Data.Employee;
using BLL.Entities;
using BLL.Exception;
using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers;

[Route("employee")]
public class EmployeeController : BaseController<EmployeeController>
{
    private readonly IEmployeeService _employeeService;

    public EmployeeController(IEmployeeService employeeService)
    {
        _employeeService = employeeService;
    }

    [HttpGet]
    [Route("employees")]
    public IActionResult Index(string search = "")
    {
        if (string.IsNullOrWhiteSpace(search))
        {
            return new JsonResult(new { employees = new List<Employee>() });
        }

        return new JsonResult(new { employees = _employeeService.GetEmployeeBySearch(search) });
    }

    //Employee page not json but view
    [HttpGet]
    [Route("{id}")]
    public IActionResult Employee(Guid id)
    {
        try
        {
            Employee employeeById = _employeeService.GetEmployeeById(id);
            return View(employeeById);
        }
        catch (ServiceException e)
        {
            return View(null);
        }
    }
}