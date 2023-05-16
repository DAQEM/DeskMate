using BLL.Data.Employee.Role;
using BLL.DTOs;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public class RoleRepository : IRoleRepository
{
    private readonly DeskMateContext _context;

    public RoleRepository(DeskMateContext context)
    {
        _context = context;
    }

    public RoleDTO? GetRoleByEmployeeId(Guid employeeId)
    {
        return _context.user
            .Include(e => e)
            .Include(e => e.roleDTO)
            .Where(e => e.Id == employeeId)
            .Select(e => e.roleDTO)
            .FirstOrDefault();
    }
}