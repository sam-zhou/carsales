using Carsales.Core.Models;
using Carsales.Dto.Abstracts;

namespace Carsales.Dto.Vehicles
{
    public class ModelDto: BaseEntityDto<int>, INamedEntityDto
    {

        public string Name { get; set; }

        public int MakeId { get; set; }

        public MakeDto Make { get; set; }

        public VehicleType VehicleType { get; set; }
    }
}
