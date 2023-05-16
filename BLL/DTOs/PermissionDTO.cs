using System.ComponentModel.DataAnnotations.Schema;

namespace BLL.DTOs
{
    public class PermissionDTO
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        [Column(TypeName = "varchar(200)")] public string Type { get; set; }
        public Guid RoleId { get; set; }
        public RoleDTO roleDTO { get; set; }
    }
}