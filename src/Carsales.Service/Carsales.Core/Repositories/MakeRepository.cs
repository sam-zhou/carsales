using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Carsales.Common.Exception;
using Carsales.Core.Models;
using Carsales.Core.Repositories.Abstracts;

namespace Carsales.Core.Repositories
{
    public interface IMakeRepository : IRepository<Make, int>
    {
        
    }

    public class MakeRepository : BaseRepository<Make, int>, IMakeRepository
    {
        public MakeRepository(DbContext dbContext)
            : base(dbContext)
        {
        }


    }
}
