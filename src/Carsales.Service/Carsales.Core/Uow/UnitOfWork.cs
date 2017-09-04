using System;
using System.Data.Entity;

namespace Carsales.Core.Uow
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private DbContext _dbContext;
        
        public UnitOfWork(DbContext context)
        {

            _dbContext = context;
        }

        public int Commit()
        {
            // Save changes with the default options
            return _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_dbContext != null)
                {
                    _dbContext.Dispose();
                    _dbContext = null;
                }
            }
        }
    }
}
