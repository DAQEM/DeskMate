namespace BLL.Data.Employee;

public interface IEmployeeService
{
    List<Entities.Employee> GetAllEmployees();
    Entities.Employee GetEmployeeById(Guid guid);
    List<Entities.Employee> GetEmployeeBySearch(string search);

    /// <summary>
    ///     Creates an employee and returns it if the employee is valid.
    /// </summary>
    /// <param name="employee">
    ///     The employee to create.
    /// </param>
    /// <returns>
    ///     Returns the employee if the employee is valid.
    ///     Otherwise returns null.
    /// </returns>
    Entities.Employee? CreateEmployee(Entities.Employee employee);
    //Entities.Employee? EditEmployee(Entities.Employee employee);
}