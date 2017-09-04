using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Carsales.Common.Exception;
using Carsales.Core.Models;
using Carsales.Core.Repositories.Abstracts;

namespace Carsales.Core.Repositories
{
    public interface IVehicleRepository : IRepository<Vehicle>
    {
        
    }

    public class VehicleRepository: BaseRepository<Vehicle>, IVehicleRepository
    {
        public VehicleRepository(DbContext dbContext)
            : base(dbContext)
        {
        }


    }
}
