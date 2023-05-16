namespace BLL.Data.Employee.Role;

public class RoleService : IRoleService
{
    private readonly IRoleRepository _roleRepository;

    public RoleService(IRoleRepository roleRepository)
    {
        _roleRepository = roleRepository;
    }

    public Entities.Role? GetRoleByEmployeeId(Guid employeeId)
    {
        return _roleRepository.GetRoleByEmployeeId(employeeId)?.ToRole();
    }
}