using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Carsales.Core.Models.Abstracts
{
    public class BaseEntity<TKey>
    {
        public virtual TKey Id { get; set; }
    }

    public class BaseEntity : BaseEntity<long>
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public override long Id { get; set; }
    }
}
