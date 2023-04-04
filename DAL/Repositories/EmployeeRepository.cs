using BLL.Data.Employee;
using BLL.DTOs;

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
        return _context.user
            .Select(u => new UserDTO()
            {
                Id = u.Id,
                Name = u.Name,
                Email = u.Email,
                Password = u.Email,
                roleDTO = u.roleDTO,
                reservationDTOs = u.reservationDTOs,
            })
            .ToList();
    }
}