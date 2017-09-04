using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Carsales.Core.Models.Attributes;
using Microsoft.AspNet.Identity;

namespace Carsales.Core.Models.Abstracts
{
    public interface IModifyEntity
    {
        DateTime? ModifiedDateTime { get; set; }

        long? ModifiedBy { get; set; }

        User ModifiedByUser { get; set; }

    }

    public class ModifyEntity<TKey> :BaseEntity<TKey>, IModifyEntity where TKey : IEquatable<TKey>
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [SqlDefaultValue("GETUTCDATE()")]
        public DateTime? ModifiedDateTime { get; set; }

        public long? ModifiedBy { get; set; }

        [ForeignKey("ModifiedBy")]
        public virtual User ModifiedByUser { get; set; }
    }
}
