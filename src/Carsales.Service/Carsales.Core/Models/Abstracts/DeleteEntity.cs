using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNet.Identity;

namespace Carsales.Core.Models.Abstracts
{
    public interface IDeleteEntity<TUser, TKey> where TUser : class, IUser<TKey> where TKey : IEquatable<TKey>
    {
        DateTime DeletedDateTime { get; set; }

        TKey DeletedBy { get; set; }

        TUser DeletedByUser { get; set; }

    }

    public interface IDeleteEntity : IDeleteEntity<User, long>
    {

    }

    public class DeleteEntity<TKey>: BaseEntity<TKey>, IDeleteEntity where TKey: IEquatable<TKey>
    {
        public DateTime DeletedDateTime { get; set; }

        public long DeletedBy { get; set; }

        [ForeignKey("ModifiedBy")]
        public virtual User DeletedByUser { get; set; }
    }
}
