using Carsales.Dto.Abstracts;

namespace Carsales.Dto.Vehicles
{
    public class MakeDto: BaseEntityDto<int>, INamedEntityDto
    {

        public string Name { get; set; }
    }
}
