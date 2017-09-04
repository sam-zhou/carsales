using System.Web;
using System.Web.Http;
using Carsales.Core;
using Carsales.Core.Repositories;
using Carsales.Core.Uow;
using System.Collections.Generic;
using Carsales.Dto.Makes;
using AutoMapper;
using System.Linq;
using Carsales.Dto.Models;

namespace Carsales.Api.Api
{
    public interface IVehicleController{
        
    }

    [AllowAnonymous]
    public class VehicleController : BaseApiController
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IMakeRepository _makeRepository;
        private readonly IModelRepository _modelRepository;


        public VehicleController(IVehicleRepository vehicleRepository, 
                                 IUnitOfWork unitOfWork, 
                                 IMakeRepository makeRepository, 
                                 IModelRepository modelRepository) : base(unitOfWork)
        {
            _vehicleRepository = vehicleRepository;
            _makeRepository = makeRepository;
            _modelRepository = modelRepository;
        }

        [HttpGet]
        public bool IsUserLoggedIn()
        {
            return HttpContext.Current.User.Identity.IsAuthenticated;
        }

        [HttpGet]
        public IEnumerable<MakeDto> GetMakes()
        {
            var makes = _makeRepository.GetAll().ToList();
            return Mapper.Map<List<MakeDto>>(makes);
        }

        [HttpPost]
        public IEnumerable<ModelDto> GetModels(GetModelsInput input) {
            var models = _modelRepository.GetModelsForMake(input.MakeId, input.VehicleType);

            return Mapper.Map<List<ModelDto>>(models);
        }
    }
}