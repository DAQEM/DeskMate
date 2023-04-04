using System.ComponentModel.DataAnnotations.Schema;

namespace BLL.DTOs
{
    public class RoleDTO
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        [Column(TypeName = "varchar(200)")] public string Type { get; set; }
        public ICollection<PermissionDTO> permissionDTO { get; set; }
        public ICollection<UserDTO> userDTO { get; set; }
    }
}