using System;
using System.ComponentModel;
using System.Linq;
using Carsales.Core.Models.Abstracts;

namespace Carsales.Dto.Abstracts
{
    public abstract class BaseEntityDto<TEntity, TKey> where TEntity: BaseEntity<TKey>
    {

        protected BaseEntityDto()
        {
            
        }

    }
}
