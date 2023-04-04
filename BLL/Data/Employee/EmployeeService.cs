using BLL.DTOs;

namespace BLL.Data.Employee;

public class EmployeeService : IEmployeeService
{
    private readonly IEmployeeRepository _employeeRepository;

    public EmployeeService(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    public List<Entities.Employee> GetAllEmployees()
    {
        List<UserDTO> empoyees = _employeeRepository.GetAllEmployees();
        return empoyees.Select(e => e.ToEmployee()).ToList();
    }
}