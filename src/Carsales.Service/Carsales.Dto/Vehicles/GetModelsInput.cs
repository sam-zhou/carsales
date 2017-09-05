using Carsales.Core.Models;

namespace Carsales.Dto.Vehicles
{
    public class GetModelsInput
    {
        public VehicleType? VehicleType { get; set; }

        public int MakeId { get; set; }
    }
}
