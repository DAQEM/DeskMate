using BLL.Data.Employee;
using BLL.Entities;
using BLL.Exception;
using Microsoft.AspNetCore.Mvc;
using MVC.Models.Employee;

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

    [HttpGet]
    [Route("edit/{id}")]
    public IActionResult Edit(Guid id)
    {
        Employee employee = _employeeService.GetEmployeeById(id);
        EditEmployeeModel editEmployeeModel = new()
        {
            Name = employee.Name,
            Password = string.Empty
        };

        return View(editEmployeeModel);
    }

    [HttpPost]
    [Route("edit/{id}")]
    public IActionResult Edit(Guid id, EditEmployeeModel editEmployeeModel)
    {
	    if (!ModelState.IsValid)
	    {
		    return View(editEmployeeModel);
	    }

	    if (editEmployeeModel.Password?.Length is > 0 and < 8)
	    {
			ModelState.AddModelError("Password", "Password must be at least 8 characters long");
			return View(editEmployeeModel);
		}

        Employee currentEmployee = _employeeService.GetEmployeeById(id);
        _employeeService.EditEmployee(currentEmployee, 
        new Employee(
            id: id,
            name: editEmployeeModel.Name,
            hashedPassword: editEmployeeModel.Password));

        return RedirectToAction("Employee", new { id = id });
    }
}