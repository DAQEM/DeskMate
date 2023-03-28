using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOS
{
    public class WorkplaceDTO
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        [Column(TypeName = "varchar(200)")]
        public string Name { get; set; }
        public Guid RoomId { get; set; }
        public RoomDTO roomDTO { get; set; }    
        public ICollection<ReservationDTO> reservationDTOs { get; set; }
        public ICollection<WorkplaceCharacteristicsDTO> workplaceCharacteristicsDTOs { get; set; } 
    }
}
