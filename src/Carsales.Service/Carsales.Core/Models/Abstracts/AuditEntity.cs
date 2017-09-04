using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Carsales.Core.Models.Attributes;

namespace Carsales.Core.Models.Abstracts
{
    public class AuditEntity : AuditEntity<long>
    {
    }

    public class AuditEntity<TKey> : BaseEntity<TKey>, ICreateEntity, IModifyEntity, IDeleteEntity
        where TKey : IEquatable<TKey>
    {
        [Required, DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [SqlDefaultValue("GETUTCDATE()")]
        public DateTime CreatedDateTime { get; set; }

        public long? CreatedBy { get; set; }

        [ForeignKey("CreatedBy")]
        public virtual User CreatedByUser { get; set; }

        public DateTime? ModifiedDateTime { get; set; }

        public long? ModifiedBy { get; set; }

        [ForeignKey("ModifiedBy")]
        public virtual User ModifiedByUser { get; set; }

        public DateTime? DeletedDateTime { get; set; }

        public long? DeletedBy { get; set; }

        [ForeignKey("DeletedBy")]
        public virtual User DeletedByUser { get; set; }
    }
}
