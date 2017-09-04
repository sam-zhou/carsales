using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Carsales.Core.Models.Attributes;
using Microsoft.AspNet.Identity;

namespace Carsales.Core.Models.Abstracts
{
    public interface IModifyEntity<TUser, TKey> where TUser : class, IUser<TKey> where TKey : IEquatable<TKey>
    {
        DateTime ModifiedDateTime { get; set; }

        TKey ModifiedBy { get; set; }

        TUser ModifiedByUser { get; set; }

    }

    public interface IModifyEntity : IModifyEntity<User, long>
    {

    }

    public class ModifyEntity<TKey> :BaseEntity<TKey>, IModifyEntity where TKey : IEquatable<TKey>
    {
        [Required, DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [SqlDefaultValue("GETUTCDATE()")]
        public DateTime ModifiedDateTime { get; set; }

        public long ModifiedBy { get; set; }

        [ForeignKey("ModifiedBy")]
        public virtual User ModifiedByUser { get; set; }
    }
}
