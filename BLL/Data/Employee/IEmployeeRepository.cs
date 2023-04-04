using BLL.DTOs;

namespace BLL.Data.Employee;

public interface IEmployeeRepository
{
    List<UserDTO> GetAllEmployees();
}