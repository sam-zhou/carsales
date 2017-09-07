using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Carsales.Core.Models;
using Carsales.Dto.Abstracts;

namespace Carsales.Dto.Vehicles
{
    public class VehicleDto: BaseEntityDto<long>, INamedEntityDto, IDescriptionEntityDto
    {
        public VehicleType VehicleType { get; set; }
        
        public int BadgeId { get; set; }

        public BadgeDto Badge { get; set; }
        
        public string Name { get; set; }

        public string Make => Badge?.Model?.Make?.Name;

        public string Model => Badge?.Model?.Name;

        public string BadgeName => Badge?.Name;

        public string Description { get; set; }

        public List<ImageDto> Images { get; set; }

        public int? Price { get; set; }

        public State State { get; set; }

        public string Postcode { get; set; }

        public string Surburb { get; set; }

        public int Year { get; set; }

        public int Odometer { get; set; }
    }
}
