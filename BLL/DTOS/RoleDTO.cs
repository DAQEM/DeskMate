using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOS
{
    public class RoleDTO
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Type { get; set; }
        public ICollection<PermissionDTO> permissionDTO { get; set; }
    }
}
