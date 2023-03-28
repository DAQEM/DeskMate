using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOS
{
    public class FloorDTO
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        [Column(TypeName = "varchar(200)")]
        public string Name { get; set; }
        public int Number { get; set; }
        public Guid LocationId { get; set; }
        public ICollection<RoomDTO> roomDTO { get; set; }
        public LocationDTO locationDTO { get; set; }
    }
}
