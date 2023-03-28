using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOS
{
    public class PermissionDTO
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        [Column(TypeName = "varchar(200)")]
        public string Type { get; set; }
        public Guid RoleId { get; set; }
        public RoleDTO roleDTO { get; set; }
    }
}
