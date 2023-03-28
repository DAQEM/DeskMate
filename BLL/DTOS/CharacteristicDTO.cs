using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOS
{
    public class CharacteristicDTO
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public int Type { get; set; }
        public ICollection<WorkplaceCharacteristicsDTO> workplaceCharacteristicsDTOs { get; set; }
    }
}
