﻿using BLL.Data.Employee;
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
            .Select(u => new UserDTO
            {
                Id = u.Id,
                Name = u.Name,
                Email = u.Email,
                Password = u.Email,
                roleDTO = u.roleDTO,
                reservationDTOs = u.reservationDTOs
            })
            .ToList();
    }

    public UserDTO? GetEmployeeById(Guid guid)
    {
        return _context.user
            .FirstOrDefault(u => u.Id == guid);
    }

    public List<UserDTO> GetEmployeeBySearch(string search)
    {
        return _context.user
            .Where(u => 
                u.Name.ToLower().Contains(search.ToLower()))
            .ToList();
    }
}