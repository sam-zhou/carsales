using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Carsales.Core.Models.Abstracts;
using Carsales.Core.Models.Interfaces;

namespace Carsales.Core.Models
{
    public enum Engine
    { 
        [Description("Unknown")]
        Unknown=0,

        [Description("1200")]
        E1200 = 1200,

        [Description("1500")]
        E1500 = 1500,

        [Description("1600")]
        E1600 = 1600,

        [Description("1800")]
        E1800 = 1800,

        [Description("2000")]
        E2000 = 2000,

        [Description("2400")]
        E2400 = 2400,

        [Description("3000")]
        E3000 = 3000,

        [Description("3500")]
        E3500 = 3500,

        [Description("4000")]
        E4000 = 4000,
    }
}
