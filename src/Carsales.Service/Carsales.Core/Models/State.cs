using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Carsales.Core.Models.Abstracts;
using Carsales.Core.Models.Interfaces;

namespace Carsales.Core.Models
{
    public enum State
    {
        Unkown = 0,
        ACT = 1,
        NSW = 2,
        NT = 3,
        QLD = 4,
        SA = 5,
        TAS = 6,
        VIC = 7,
        WA = 8
    }
}
