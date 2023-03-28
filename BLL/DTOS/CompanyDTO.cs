using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOS
{
    public class CompanyDTO
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        [Column(TypeName = "varchar(200)")]
        public string Name { get; set; }
        public ICollection<LocationDTO>? locationDTOList { get; set; }
        public ICollection<UserDTO> userDTO { get; set; }
    }
}
