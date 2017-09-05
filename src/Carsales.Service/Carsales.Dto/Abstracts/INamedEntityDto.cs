using System;
using System.ComponentModel;
using System.Linq;
using Carsales.Core.Models.Abstracts;

namespace Carsales.Dto.Abstracts
{
    public interface INamedEntityDto
    {
        string Name { get; set; }
    }

    
}
