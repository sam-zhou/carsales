using Carsales.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carsales.Dto.Models
{
    public class GetModelsInput
    {
        public VehicleType VehicleType { get; set; }

        public int MakeId { get; set; }
    }
}
