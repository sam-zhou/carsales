using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Carsales.Common.Exception;
using Carsales.Core.Models;
using Carsales.Core.Repositories.Abstracts;

namespace Carsales.Core.Repositories
{
    public interface IModelRepository : IRepository<Model, int>
    {
        IQueryable<Model> GetModelsForMake(int makeId, VehicleType type);
    }

    public class ModelRepository : BaseRepository<Model, int>, IModelRepository
    {
        public ModelRepository(DbContext dbContext)
            : base(dbContext)
        {
        }

        public IQueryable<Model> GetModelsForMake(int makeId, VehicleType type)
        {
            return Entities.Set<Model>().Where(q => q.MakeId == makeId && q.VehicleType == type);
        }
    }
}
