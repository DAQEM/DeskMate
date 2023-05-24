using System.ComponentModel.DataAnnotations.Schema;
using BLL.Entities;

namespace BLL.DTOs;

public class RoleDTO
{
    public Guid Id { get; set; } = Guid.NewGuid();
    [Column(TypeName = "varchar(200)")] public string Type { get; set; }
    public ICollection<PermissionDTO> permissionDTO { get; set; }
    public ICollection<UserDTO> userDTO { get; set; }

    public Role ToRole()
    {
        return new Role(Id,
            Type,
            permissionDTO.Select(p => p.ToPermission()).ToList(),
            userDTO.Select(u => u.ToSmallEmployee()).FirstOrDefault());
    }

    public Role ToSmallRole()
    {
        return new Role(Id,
            Type,
            permissionDTO.Select(p => p.ToSmallPermission()).ToList());
    }
}