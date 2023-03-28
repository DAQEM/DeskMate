using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOS
{
    public class LocationDTO
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Postal { get; set; }
        public string Country { get; set; }
        public string StreetName { get; set; }
        public string HouseNumber { get; set; }
        public string City { get; set; }
        public Guid CompanyId { get; set; }
        public CompanyDTO companyDTO { get; set; }
        public ICollection<FloorDTO> floorDTO { get; set; }
    }
}
