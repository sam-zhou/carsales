using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Carsales.Core.Models.Abstracts;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Carsales.Core.Models
{
    public class Image: AuditEntity<long>
    {
        [Required]
        public string FileName { get; set; }

        [Required]
        public string Path { get; set; }

        [Required]
        public string ThumbnailPath { get; set; }

        public int Order { get; set; }

        [Required]
        public long VehicleId { get; set; }

        [ForeignKey("VehicleId")]
        public virtual Vehicle Vehicle { get; set; }
    }
}
