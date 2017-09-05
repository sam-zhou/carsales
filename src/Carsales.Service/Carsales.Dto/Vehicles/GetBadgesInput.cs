using Carsales.Core.Models;

namespace Carsales.Dto.Vehicles
{
    public class GetBadgesInput
    {
        public BadgeType? BadgeType { get; set; }

        public int ModelId { get; set; }
    }
}
