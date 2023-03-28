using BLL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOS
{
    public class RoomDTO
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public Guid FloorId { get; set; }
        public FloorDTO floorDTO { get; set; }
        public ICollection<WorkplaceDTO> workplaceDTO { get; set; }
    }
}
