using BLL.DTOs;

namespace BLL.Data.Employee;

public interface IEmployeeRepository
{
    List<UserDTO> GetAllEmployees();
    UserDTO? GetEmployeeById(Guid guid);
    List<UserDTO> GetEmployeeBySearch(string search);
    void CreateEmployee(UserDTO toUserDto);
    //void EditEmployee(UserDTO userDto);
}