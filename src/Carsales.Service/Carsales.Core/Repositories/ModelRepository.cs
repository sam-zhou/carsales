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

    }

    public class ModelRepository : BaseRepository<Model, int>, IModelRepository
    {
        public ModelRepository(DbContext dbContext)
            : base(dbContext)
        {
        }
    }
}
