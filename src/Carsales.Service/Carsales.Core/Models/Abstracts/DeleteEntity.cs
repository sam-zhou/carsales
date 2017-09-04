using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNet.Identity;

namespace Carsales.Core.Models.Abstracts
{
    public interface IDeleteEntity
    {
        DateTime? DeletedDateTime { get; set; }

        long? DeletedBy { get; set; }

        User DeletedByUser { get; set; }

    }

    public class DeleteEntity<TKey>: BaseEntity<TKey>, IDeleteEntity where TKey: IEquatable<TKey>
    {
        public DateTime? DeletedDateTime { get; set; }

        public long? DeletedBy { get; set; }

        [ForeignKey("ModifiedBy")]
        public virtual User DeletedByUser { get; set; }
    }
}
