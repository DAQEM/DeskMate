using BLL.DTOs;
using BLL.Entities;
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

        return employee.ToEmployeeWithRole();
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

  public Entities.Employee? EditEmployee(Entities.Employee currentEmployee, Entities.Employee editedEmployee)
    {
        if (!string.IsNullOrWhiteSpace(editedEmployee.HashedPassword) && !string.IsNullOrEmpty(editedEmployee.HashedPassword))
        {
            editedEmployee.HashPassword();

            if (currentEmployee.HashedPassword != editedEmployee.HashedPassword)
            {
                currentEmployee = new(
                    currentEmployee.Id,
                    currentEmployee.Name,
                    currentEmployee.Email,
                    editedEmployee.HashedPassword,
                    role: currentEmployee.Role
                );
            }
        }

        if (!string.IsNullOrWhiteSpace(editedEmployee.Name) && !string.IsNullOrEmpty(editedEmployee.Name))
        {
            if (currentEmployee.Name != editedEmployee.Name)
            {
                currentEmployee = new(
                    currentEmployee.Id,
                    editedEmployee.Name,
                    currentEmployee.Email,
                    currentEmployee.HashedPassword,
                    role: currentEmployee.Role
                );
            }
        }

        _employeeRepository.EditEmployee(currentEmployee.ToUserDTO());

        return currentEmployee;
    }
}