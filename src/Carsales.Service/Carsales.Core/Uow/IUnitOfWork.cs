using System;

namespace Carsales.Core.Uow
{
    public interface IUnitOfWork : IDisposable
    {
        int Commit();
    }
}
