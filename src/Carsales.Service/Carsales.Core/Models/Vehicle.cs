using System.Collections;
using System.Collections.Generic;
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

        [NotMapped]
        public string Make => Badge.Model.Make.Name;

        [NotMapped]
        public string Model => Badge.Model.Name;

        [NotMapped]
        public string BadgeName => Badge.Name;

        [Required]
        [MaxLength(500)]
        public string Description { get; set; }

        public virtual ICollection<Image> Images { get; set; }

        public int? Price { get; set; }

        public State State { get; set; }

        [MaxLength(4)]
        public string Postcode { get; set; }

        [MaxLength(30)]
        public string Surburb { get; set; }

        public Vehicle()
        {
            Images = new List<Image>();
        }
    }
}
