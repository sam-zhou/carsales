using Carsales.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carsales.Dto.Models
{
    public class ModelDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int MakeId { get; set; }

        public VehicleType VehicleType { get; set; }
    }
}
