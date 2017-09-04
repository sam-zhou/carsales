using System.Web;
using System.Web.Http;
using Carsales.Core;
using Carsales.Core.Repositories;
using Carsales.Core.Uow;

namespace Carsales.Api.Api
{
    public interface IVehicleController{
        
    }

    [AllowAnonymous]
    public class VehicleController : BaseApiController
    {
        private readonly IVehicleRepository _vehicleRepository;

        public VehicleController(IVehicleRepository vehicleRepository, IUnitOfWork unitOfWork): base(unitOfWork)
        {
            _vehicleRepository = vehicleRepository;
        }

        [AllowAnonymous]
        [HttpGet]
        public bool IsUserLoggedIn()
        {

            return HttpContext.Current.User.Identity.IsAuthenticated;



        }
    }
}