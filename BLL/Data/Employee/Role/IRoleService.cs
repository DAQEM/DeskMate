namespace BLL.Data.Employee.Role;

public interface IRoleService
{
    Entities.Role? GetRoleByEmployeeId(Guid employeeId);
}