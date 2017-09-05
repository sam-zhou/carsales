using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Carsales.Core.Models;
using Carsales.Dto.Vehicles;
using Xunit;

namespace Carsales.Api.Tests.VehicleController
{
    public class VehicleControllerTests: TestBase
    {
        private readonly Api.VehicleController _controller;
        public VehicleControllerTests()
        {
            _controller = new Api.VehicleController(VehicleRepository.Object, UnitOfWork.Object, MakeRepository.Object, ModelRepository.Object);
        }

        [Fact]
        public async Task GetMakesShouldBeThree()
        {
            var result = await _controller.GetMakesAsync();

            Assert.Equal(true, result.Any());
            Assert.Equal(3, result.Count);
        }

        [Fact]
        public async Task GetCarModelsShouldBeTwo()
        {
            var result = await _controller.GetModelsAsync(new GetModelsInput
            {
                MakeId = 2,
                VehicleType = VehicleType.Car
            });

            Assert.Equal(true, result.Any());
            Assert.Equal(2, result.Count);
        }

        [Fact]
        public async Task GetBikeModelsShouldBeEmpty()
        {
            var result = await _controller.GetModelsAsync(new GetModelsInput
            {
                MakeId = 2,
                VehicleType = VehicleType.Bike
            });

            Assert.Equal(false, result.Any());
        }

        [Fact]
        public async Task GetBikeModelsShouldBeOne()
        {
            var result = await _controller.GetModelsAsync(new GetModelsInput
            {
                MakeId = 1,
                VehicleType = VehicleType.Bike
            });

            Assert.Equal(1, result.Count);
        }

        [Fact]
        public async Task GetCarModelsShouldBeEmpty()
        {
            var result = await _controller.GetModelsAsync(new GetModelsInput
            {
                MakeId = 3,
                VehicleType = VehicleType.Car
            });

            Assert.Equal(false, result.Any());
        }
    }
}
