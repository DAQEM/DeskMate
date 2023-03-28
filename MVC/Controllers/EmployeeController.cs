using BLL.Entities;
using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers;

public class EmployeeController : BaseController<EmployeeController>
{
    private readonly List<Employee> employees = new()
    {
        new Employee(Guid.NewGuid(), "Henk"),
        new Employee(Guid.NewGuid(), "Jan"),
        new Employee(Guid.NewGuid(), "Rik"),
        new Employee(Guid.NewGuid(), "Karla"),
        new Employee(Guid.NewGuid(), "Piet"),
        new Employee(Guid.NewGuid(), "Jasmijn"),
        new Employee(Guid.NewGuid(), "Harrie"),
        new Employee(Guid.NewGuid(), "Karel"),
        new Employee(Guid.NewGuid(), "Klaas"),
        new Employee(Guid.NewGuid(), "Kees"),
        new Employee(Guid.NewGuid(), "Klaasje")
    };

    [HttpGet]
    [Route("employees")]
    public IActionResult Index(string search = "")
    {
        if (string.IsNullOrWhiteSpace(search))
        {
            return new JsonResult(new { employees = new List<Employee>() });
        }

        List<Employee> filteredEmployees = employees
            .Where(e => e.Name.ToLower().Contains(search.ToLower())
                        || e.Email.ToLower().Contains(search.ToLower())).ToList();
        return new JsonResult(new { employees = filteredEmployees });
    }
}