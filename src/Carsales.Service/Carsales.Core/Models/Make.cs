using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Carsales.Core.Models.Abstracts;
using Carsales.Core.Models.Interfaces;

namespace Carsales.Core.Models
{
    public class Make: AuditEntity<int>, INameEntity
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
