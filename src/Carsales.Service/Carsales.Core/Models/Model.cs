using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Carsales.Core.Models.Abstracts;
using Carsales.Core.Models.Interfaces;

namespace Carsales.Core.Models
{
    public class Model: AuditEntity<int>, INameEntity
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public int MakeId { get; set; }

        [ForeignKey("MakeId")]
        public virtual Make Make { get; set; }

        public VehicleType VehicleType { get; set; }
    }
}
