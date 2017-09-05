using Carsales.Core.Models;
using Carsales.Dto.Abstracts;

namespace Carsales.Dto.Vehicles
{
    public class BadgeDto: BaseEntityDto<int>, INamedEntityDto
    {
        public string Name { get; set; }

        public int ModelId { get; set; }

        public ModelDto Model { get; set; }

        public VehicleType VehicleType { get; set; }
    }
}
