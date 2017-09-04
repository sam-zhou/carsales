using System.Web;
using System.Web.Http;
using Carsales.Core;
using Carsales.Core.Repositories;
using Carsales.Core.Uow;
using System.Collections.Generic;
using Carsales.Dto.Makes;
using AutoMapper;
using System.Linq;

namespace Carsales.Api.Api
{
    public interface IVehicleController{
        
    }

    [AllowAnonymous]
    public class VehicleController : BaseApiController
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IMakeRepository _makeRepository;

        public VehicleController(IVehicleRepository vehicleRepository, IUnitOfWork unitOfWork, IMakeRepository makeRepository): base(unitOfWork)
        {
            _vehicleRepository = vehicleRepository;
            _makeRepository = makeRepository;
        }

        [AllowAnonymous]
        [HttpGet]
        public bool IsUserLoggedIn()
        {

            return HttpContext.Current.User.Identity.IsAuthenticated;



        }

        [AllowAnonymous]
        [HttpGet]
        public IEnumerable<MakeDto> GetMakes()
        {
            var makes = _makeRepository.GetAll().ToList();


            return Mapper.Map<List<MakeDto>>(makes);



        }
    }
}