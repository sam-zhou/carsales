using System.Web;
using System.Web.Http;
using Carsales.Core;
using Carsales.Core.Repositories;
using Carsales.Core.Uow;
using System.Collections.Generic;
using System.Data.Entity;
using AutoMapper;
using System.Linq;
using System.Threading.Tasks;
using Carsales.Common.Exception;
using Carsales.Common.Extension;
using Carsales.Core.Models;
using Carsales.Dto.Common;
using Carsales.Dto.Vehicles;
using System;

namespace Carsales.Api.Api
{
    public interface IVehicleController
    {
        Task<List<MakeDto>> GetMakesAsync();

        Task<List<ModelDto>> GetModelsAsync(GetModelsInput input);

        Task<List<BadgeDto>> GetBadgesAsync(GetBadgesInput input);

        Task<PagedResultDto<VehicleDto>> GetVehiclesAsync(GetVehiclesInput input);
        Task<VehicleDto> GetVehicleAsync(GetVehicleInput input);

    }

    [AllowAnonymous]
    public class VehicleController : BaseApiController, IVehicleController
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IMakeRepository _makeRepository;
        private readonly IModelRepository _modelRepository;
        private readonly IBadgeRepository _badgeRepository;

        public VehicleController(IVehicleRepository vehicleRepository, 
                                 IUnitOfWork unitOfWork, 
                                 IMakeRepository makeRepository, 
                                 IModelRepository modelRepository,
                                 IBadgeRepository badgeRepository) : base(unitOfWork)
        {
            _vehicleRepository = vehicleRepository;
            _makeRepository = makeRepository;
            _modelRepository = modelRepository;
            _badgeRepository = badgeRepository;
        }

        [HttpGet]
        public bool IsUserLoggedIn()
        {
            return HttpContext.Current.User.Identity.IsAuthenticated;
        }

        [HttpGet]
        public async Task<List<MakeDto>> GetMakesAsync()
        {
            var makes = await _makeRepository.GetAll().ToListAsync();
            return Mapper.Map<List<MakeDto>>(makes);
        }

        [HttpPost]
        public async Task<List<ModelDto>> GetModelsAsync(GetModelsInput input)
        {
            var models = await _modelRepository
                .GetAll()
                .Where(q => q.MakeId == input.MakeId)
                .WhereIf(input.VehicleType.HasValue, q => q.VehicleType == input.VehicleType)
                .ToListAsync();

            return Mapper.Map<List<ModelDto>>(models);
        }

        [HttpPost]
        public async Task<List<BadgeDto>> GetBadgesAsync(GetBadgesInput input)
        {
            var models = await _badgeRepository
                .GetAll()
                .Where(q => q.ModelId == input.ModelId)
                .WhereIf(input.BadgeType.HasValue, q => q.BadgeType == input.BadgeType)
                .ToListAsync();

            return Mapper.Map<List<BadgeDto>>(models);
        }

        [HttpPost]
        public async Task<PagedResultDto<VehicleDto>> GetVehiclesAsync(GetVehiclesInput input)
        {
            var query =  _vehicleRepository.GetAll()
                .WhereIf(input.VehicleType.HasValue, x => x.VehicleType == input.VehicleType.Value)
                .WhereIf(input.BadgeType.HasValue, x => x.Badge.BadgeType == input.BadgeType.Value)
                .WhereIf(input.Filter != null, x => x.Name.Contains(input.Filter) || x.Description.Contains(input.Filter) || x.Badge.Name.Contains(input.Filter) || x.Badge.Model.Name.Contains(input.Filter) || x.Badge.Model.Make.Name.Contains(input.Filter));

            var totoalCount = await query.CountAsync();
            var models = await query
                .PageBy(input)
                .ToListAsync();

            var results = Mapper.Map<List<VehicleDto>>(models);

            return new PagedResultDto<VehicleDto>(totoalCount, results);
        }

        [HttpPost]
        public async Task<VehicleDto> GetVehicleAsync(GetVehicleInput input)
        {
            var entity = await _vehicleRepository.GetAsync(input.Id);
            if (entity == null)
            {
                throw new UserFriendlyException($"Vehicle #{input.Id} not found");
            }

            return Mapper.Map<VehicleDto>(entity);
        }

        [HttpPost]
        public async Task<VehicleDto> InsertOrUpdateVehicle(VehicleDto input)
        {
            if (input.Id != 0)
            {
                return await UpdateVehicle(input);
            }
            else
            {
                return await InsertVehicle(input);
            }
        }

        private async Task<VehicleDto> UpdateVehicle(VehicleDto input)
        {
            var entity = await _vehicleRepository.GetAsync(input.Id);
            if (entity == null)
            {
                throw new UserFriendlyException($"Vehicle #{input.Id} not found");
            }

            entity.BadgeId = input.BadgeId;
            entity.Name = input.Name;
            entity.Description = input.Description;

            await _vehicleRepository.SaveAsync();

            return Mapper.Map<VehicleDto>(entity);
        }

        private async Task<VehicleDto> InsertVehicle(VehicleDto input)
        {
            var newVehicle = Mapper.Map<Vehicle>(input);
            //set badge to null to break the map
            newVehicle.Badge = null;

            newVehicle = _vehicleRepository.Add(newVehicle);

            await _vehicleRepository.SaveAsync();

            return Mapper.Map<VehicleDto>(newVehicle);
        }
    }
}