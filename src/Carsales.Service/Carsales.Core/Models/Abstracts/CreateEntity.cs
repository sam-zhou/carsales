using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Carsales.Core.Models.Attributes;
using Microsoft.AspNet.Identity;

namespace Carsales.Core.Models.Abstracts
{
    public interface ICreateEntity<TUser, TKey> where TUser : class, IUser<TKey> where TKey : IEquatable<TKey>
    {
        DateTime CreatedDateTime { get; set; }

        TKey CreatedBy { get; set; }

        TUser CreatedByUser { get; set; }

    }

    public interface ICreateEntity: ICreateEntity<User, long>
    {
        
    }

    public class CreateEntity<TUser, TKey>: BaseEntity<TKey>, ICreateEntity where TKey : IEquatable<TKey>
    {
        [Required, DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [SqlDefaultValue("GETUTCDATE()")]
        public DateTime CreatedDateTime { get; set; }

        public long CreatedBy { get; set; }

        [ForeignKey("CreatedBy")]
        public virtual User CreatedByUser { get; set; }
    }
}
