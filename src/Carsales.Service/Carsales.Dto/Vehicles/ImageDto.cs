using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Carsales.Core.Models;
using Carsales.Dto.Abstracts;

namespace Carsales.Dto.Vehicles
{
    public class ImageDto: BaseEntityDto<long>
    {
        public string FileName { get; set; }

        public string Path { get; set; }

        public string ThumbnailPath { get; set; }

        public int Order { get; set; }

        public long VehicleId { get; set; }

    }
}
