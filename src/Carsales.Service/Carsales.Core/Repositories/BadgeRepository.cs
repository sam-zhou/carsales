using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Carsales.Common.Exception;
using Carsales.Core.Models;
using Carsales.Core.Repositories.Abstracts;

namespace Carsales.Core.Repositories
{
    public interface IBadgeRepository : IRepository<Badge, int>
    {
        IQueryable<Badge> GetBadgesForModel(int modelId);
    }

    public class BadgeRepository : BaseRepository<Badge, int>, IBadgeRepository
    {
        public BadgeRepository(DbContext dbContext)
            : base(dbContext)
        {
        }

        public IQueryable<Badge> GetBadgesForModel(int modelId)
        {
            return Entities.Set<Badge>().Where(q => q.ModelId == modelId);
        }
    }
}
