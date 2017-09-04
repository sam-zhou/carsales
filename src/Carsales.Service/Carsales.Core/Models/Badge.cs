using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Carsales.Core.Models.Abstracts;
using Carsales.Core.Models.Interfaces;

namespace Carsales.Core.Models
{
    public class Badge: AuditEntity<int>, INameEntity
    {
        [Required]
        [MaxLength(250)]
        public string Name { get; set; }

        [Required]
        public int ModelId { get; set; }

        [ForeignKey("ModelId")]
        public virtual Model Model { get; set; }

        [Required]
        public Engine Engine { get; set; }

        public int Doors { get; set; }

        public int Wheels { get; set; }

        public BadgeType BadgeType { get; set; }
    }
}
