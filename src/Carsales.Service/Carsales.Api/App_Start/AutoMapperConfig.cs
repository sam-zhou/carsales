using AutoMapper;
using Carsales.Core.Models;
using Carsales.Dto.Makes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Carsales.Api
{
    public class AutoMapperConfig
    {
        public static void Initialize()
        {
            Mapper.Initialize((config) =>
            {
                config.CreateMap<Make, MakeDto>().ReverseMap();
            });
        }
    }
}