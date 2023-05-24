namespace MVC.Models;

public class EmployeeModel
{
    public EmployeeModel()
    {
        Id = Guid.Empty;
        Name = "";
        Email = "";
    }

    public EmployeeModel(BLL.Entities.Employee employee)
    {
        Id = employee.Id;
        Name = employee.Name;
        Email = employee.Email;
    }

    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
}