namespace BLL.Data.Employee;

public interface IEmployeeService
{
    List<Entities.Employee> GetAllEmployees();
    Entities.Employee GetEmployeeById(Guid guid);
    List<Entities.Employee> GetEmployeeBySearch(string search);
}