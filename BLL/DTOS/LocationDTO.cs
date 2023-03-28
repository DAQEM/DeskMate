﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOS
{
    public class LocationDTO
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [Column(TypeName = "varchar(200)")] 
        public string Name { get; set; }
        [Column(TypeName = "varchar(200)")]
        public string Postal { get; set; }
        [Column(TypeName = "varchar(200)")]
        public string Country { get; set; }
        [Column(TypeName = "varchar(200)")]
        public string StreetName { get; set; }
        [Column(TypeName = "varchar(200)")]
        public string HouseNumber { get; set; }
        [Column(TypeName = "varchar(200)")]
        public string City { get; set; }
        public Guid CompanyId { get; set; }
        public CompanyDTO companyDTO { get; set; }
        public ICollection<FloorDTO> floorDTO { get; set; }
    }
}