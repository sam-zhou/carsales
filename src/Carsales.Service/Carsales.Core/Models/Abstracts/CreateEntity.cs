using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Carsales.Core.Models.Attributes;
using Microsoft.AspNet.Identity;

namespace Carsales.Core.Models.Abstracts
{
    public interface ICreateEntity
    {
        DateTime CreatedDateTime { get; set; }

        long? CreatedBy { get; set; }

        User CreatedByUser { get; set; }

    }

    public class CreateEntity<TUser, TKey>: BaseEntity<TKey>, ICreateEntity where TKey : IEquatable<TKey>
    {
        public DateTime CreatedDateTime { get; set; }

        public long? CreatedBy { get; set; }

        [ForeignKey("CreatedBy")]
        public virtual User CreatedByUser { get; set; }
    }
}
