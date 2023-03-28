using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOS
{
    public class WorkplaceCharacteristicsDTO
    {

        public Guid WorkspaceId { get; set; }
        public Guid CharacteristicId { get; set; }
        public int Amount { get; set; }
        public WorkplaceDTO workplaceDTO { get; set; }
        public CharacteristicDTO characteristicDTO { get; set; }
    }
}
