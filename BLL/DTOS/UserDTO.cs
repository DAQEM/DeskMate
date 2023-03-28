using BLL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOS
{
    public class UserDTO
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        [Column(TypeName = "varchar(200)")]
        public string Name { get; set; }
        [Column(TypeName = "varchar(200)")]
        public string Email { get; set; }
        [Column(TypeName = "varchar(256)")]
        public string Password { get; set; }
        public Guid RoleId { get; set; }
        public Guid CompanyId { get; set; }

        // Navigation properties
        public RoleDTO roleDTO { get; set; }
        public CompanyDTO companyDTO { get; set; }
        public ICollection<ReservationDTO> reservationDTOs { get; set; }
    }
}
