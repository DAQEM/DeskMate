using BLL.DTOs;
using BLL.Exception;

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

    public Entities.Employee GetEmployeeById(Guid guid)
    {
        UserDTO? employee = _employeeRepository.GetEmployeeById(guid);
        if (employee == null)
        {
            throw new ServiceException(nameof(Entities.Employee), guid.ToString());
        }

        return employee.ToEmployee();
    }

    public List<Entities.Employee> GetEmployeeBySearch(string search)
    {
        List<UserDTO> employees = _employeeRepository.GetEmployeeBySearch(search);
        return employees.Select(e => e.ToEmployee()).ToList();
    }

    public Entities.Employee? CreateEmployee(Entities.Employee employee)
    {
        if (!string.IsNullOrWhiteSpace(employee.Name)
            && !string.IsNullOrWhiteSpace(employee.Email)
            && !string.IsNullOrWhiteSpace(employee.HashedPassword))
        {
            Entities.Employee newEmployee = new(
                Guid.NewGuid(),
                employee.Name,
                employee.Email,
                employee.HashedPassword
            );
            newEmployee.HashPassword();
            _employeeRepository.CreateEmployee(newEmployee.ToUserDTO());
            return newEmployee;
        }

        return null;
    }
}