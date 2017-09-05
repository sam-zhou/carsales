using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Carsales.Core.Models;
using Carsales.Core.Repositories;
using Carsales.Core.Uow;
using Moq;
using Xunit;

namespace Carsales.Api.Tests
{
    public abstract class TestBase
    {
        protected readonly Mock<IUnitOfWork> UnitOfWork;
        protected readonly Mock<IMakeRepository> MakeRepository;
        protected readonly Mock<IModelRepository> ModelRepository;
        protected readonly Mock<IBadgeRepository> BadgeRepository;
        protected readonly Mock<IVehicleRepository> VehicleRepository;
        protected TestBase()
        {
            UnitOfWork = new Mock<IUnitOfWork>();

            MakeRepository = new Mock<IMakeRepository>();
            var makes = new List<Make>
            {
                new Make {Id = 1, Name = "BMW"},
                new Make {Id = 2, Name = "Benz"},
                new Make {Id = 3, Name = "Audi"}
            }.AsQueryable();

            MakeRepository.Setup(x => x.GetAll()).Returns(GetAsyncDbSet(makes));


            ModelRepository = new Mock<IModelRepository>();
            var models = new List<Model>
            {
                new Model {Id = 1, Name = "X1", MakeId = 1, VehicleType = VehicleType.Car},
                new Model {Id = 2, Name = "X2", MakeId = 1, VehicleType = VehicleType.Car},
                new Model {Id = 3, Name = "X3", MakeId = 1, VehicleType = VehicleType.Car},
                new Model {Id = 4, Name = "X4", MakeId = 1, VehicleType = VehicleType.Car},
                new Model {Id = 5, Name = "X5", MakeId = 1, VehicleType = VehicleType.Car},
                new Model {Id = 6, Name = "X6", MakeId = 1, VehicleType = VehicleType.Car},
                new Model {Id = 7, Name = "1 Series", MakeId = 1, VehicleType = VehicleType.Car},
                new Model {Id = 8, Name = "3 Series", MakeId = 1, VehicleType = VehicleType.Car},
                new Model {Id = 9, Name = "4 Series", MakeId = 1, VehicleType = VehicleType.Car},
                new Model {Id = 10, Name = "5 Series", MakeId = 1, VehicleType = VehicleType.Car},
                new Model {Id = 11, Name = "7 Series", MakeId = 1, VehicleType = VehicleType.Car},
                new Model {Id = 11, Name = "Bike", MakeId = 1, VehicleType = VehicleType.Bike},
                new Model {Id = 11, Name = "C Series", MakeId = 2, VehicleType = VehicleType.Car},
                new Model {Id = 11, Name = "E Series", MakeId = 2, VehicleType = VehicleType.Car},
            }.AsQueryable();

            ModelRepository.Setup(x => x.GetAll()).Returns(GetAsyncDbSet(models));

            

            BadgeRepository = new Mock<IBadgeRepository>();
            VehicleRepository = new Mock<IVehicleRepository>();

            Initialise();
        }

        //For Async Test
        private DbSet<TEntity> GetAsyncDbSet<TEntity>(IQueryable<TEntity> entities) where TEntity: class
        {
            var mockSet = new Mock<DbSet<TEntity>>();
            mockSet.As<IDbAsyncEnumerable<TEntity>>()
                .Setup(q => q.GetAsyncEnumerator())
                .Returns(new TestDbAsyncEnumerator<TEntity>(entities.GetEnumerator()));

            mockSet.As<IQueryable<TEntity>>()
                .Setup(m => m.Provider)
                .Returns(new TestDbAsyncQueryProvider<TEntity>(entities.Provider));
            mockSet.As<IQueryable<TEntity>>().Setup(m => m.Expression).Returns(entities.Expression);
            mockSet.As<IQueryable<TEntity>>().Setup(m => m.ElementType).Returns(entities.ElementType);
            mockSet.As<IQueryable<TEntity>>().Setup(m => m.GetEnumerator()).Returns(entities.GetEnumerator());

            return mockSet.Object;
        }

        private void Initialise()
        {
            AutoMapperConfig.Initialize();
        }
    }
}
