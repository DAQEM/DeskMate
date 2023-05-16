using BLL.DTOs;

namespace BLL.Data.Employee.Role;

public interface IRoleRepository
{
    RoleDTO? GetRoleByEmployeeId(Guid employeeId);
}