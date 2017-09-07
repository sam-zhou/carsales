using Carsales.Core.Models;
using Carsales.Dto.Abstracts;

namespace Carsales.Dto.Vehicles
{
    public class BadgeDto: BaseEntityDto<int>, INamedEntityDto
    {
        public string Name { get; set; }

        public int ModelId { get; set; }

        public ModelDto Model { get; set; }

        public Engine Engine { get; set; }

        public int Doors { get; set; }

        public int Wheels { get; set; }

        public BadgeType BadgeType { get; set; }

        public int Year { get; set; }
    }
}
