using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOS
{
    public class PermissionDTO
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Type { get; set; }
        public Guid RoleId { get; set; }
        public RoleDTO roleDTO { get; set; }
    }
}
