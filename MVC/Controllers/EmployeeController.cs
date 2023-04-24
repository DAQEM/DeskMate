using BLL.Data.Employee;
using BLL.Entities;
using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers;

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
}