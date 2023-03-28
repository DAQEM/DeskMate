using BLL.Entities;

namespace MVC.Models;

public class EmployeeModel
{
    public EmployeeModel()
    {
        Id = Guid.Empty;
        Name = "";
        Email = "";
    }

    public EmployeeModel(Employee employee)
    {
        Id = employee.Id;
        Name = employee.Name;
        Email = employee.Email;
    }

    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
}