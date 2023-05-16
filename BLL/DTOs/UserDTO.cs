using System.ComponentModel.DataAnnotations.Schema;
using BLL.Entities;

namespace BLL.DTOs;

public class UserDTO
{
    public Guid Id { get; set; } = Guid.NewGuid();
    [Column(TypeName = "varchar(200)")] public string Name { get; set; }
    [Column(TypeName = "varchar(200)")] public string Email { get; set; }
    [Column(TypeName = "varchar(256)")] public string Password { get; set; }
    public Guid RoleId { get; set; }
    public Guid CompanyId { get; set; }

    // Navigation properties
    public RoleDTO roleDTO { get; set; }
    public CompanyDTO companyDTO { get; set; }
    public ICollection<ReservationDTO> reservationDTOs { get; set; }

    public Employee ToEmployee()
    {
        return new Employee(
            Id,
            Name,
            Email,
            Password,
            new List<Reservation>());
    }

    public Employee ToSmallEmployee()
    {
        return new Employee(
            Id,
            Name,
            Email);
    }
}