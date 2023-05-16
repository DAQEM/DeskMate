using BLL.Data.Employee;
using BLL.DTOs;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly DeskMateContext _context;

    public EmployeeRepository(DeskMateContext context)
    {
        _context = context;
    }

    public List<UserDTO> GetAllEmployees()
    {
        return _context.user.ToList();
    }

    public UserDTO? GetEmployeeById(Guid guid)
    {
        return _context.user
            .Include(u => u.roleDTO)
            .Include(u => u.roleDTO.permissionDTO)
            .FirstOrDefault(u => u.Id == guid);
    }

    public List<UserDTO> GetEmployeeBySearch(string search)
    {
        return _context.user
            .Where(u =>
                u.Name.ToLower().Contains(search.ToLower()))
            .ToList();
    }

    public void CreateEmployee(UserDTO toUserDto)
    {
        _context.user.Add(toUserDto);
        _context.SaveChanges();
    }

    public void EditEmployee(UserDTO userDto)
    {
        UserDTO? existingUser = _context.user.Find(userDto.Id);

        if (existingUser != null)
        {
            _context.Entry(existingUser).State = EntityState.Detached;

            _context.Attach(userDto);
            _context.Entry(userDto).State = EntityState.Modified;

            _context.SaveChanges();
        }
    }
}