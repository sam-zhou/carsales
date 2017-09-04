using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Carsales.Core.Models.Abstracts;
using Carsales.Core.Models.Interfaces;

namespace Carsales.Core.Models
{
    public class Vehicle: AuditEntity, INameDescriptionEntity
    {
        public VehicleType VehicleType { get; set; }

        [Required]
        public int BadgeId { get; set; }

        [ForeignKey("BadgeId")]
        public virtual Badge Badge { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(500)]
        public string Description { get; set; }
    }
}
