using System;
using System.ComponentModel;
using System.Linq;
using Carsales.Core.Models.Abstracts;

namespace Carsales.Dto.Abstracts
{
    public abstract class BaseEntityDto
    {

    }

    public abstract class BaseEntityDto<TKey> : BaseEntityDto
    {
        public TKey Id { get; set; }

        
    }

    public abstract class BaseEntityDto<TEntity, TKey> : BaseEntityDto<TKey> where TEntity: BaseEntity<TKey>
    {

        
    }
}
