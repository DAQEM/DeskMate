using System.ComponentModel.DataAnnotations.Schema;

namespace BLL.DTOs
{
    public class CompanyDTO
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        [Column(TypeName = "varchar(200)")] public string Name { get; set; }
        public ICollection<LocationDTO>? locationDTOList { get; set; }
        public ICollection<UserDTO> userDTO { get; set; }
    }
}