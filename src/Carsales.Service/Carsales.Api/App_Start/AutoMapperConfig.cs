using AutoMapper;
using Carsales.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Carsales.Dto.Vehicles;

namespace Carsales.Api
{
    public class AutoMapperConfig
    {
        public static void Initialize()
        {
            Mapper.Initialize((config) =>
            {
                config.CreateMap<Make, MakeDto>().ReverseMap();

                config.CreateMap<Model, ModelDto>().ReverseMap();

                config.CreateMap<Badge, BadgeDto>().ReverseMap();

                config.CreateMap<Vehicle, VehicleDto>().ReverseMap();
            });
        }
    }
}