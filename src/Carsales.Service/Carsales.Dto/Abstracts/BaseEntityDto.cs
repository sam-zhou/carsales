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

        protected BaseEntityDto(TEntity data)
        {
            if (data != null)
            {
                var entityProperties = TypeDescriptor.GetProperties(typeof(TEntity)).Cast<PropertyDescriptor>().ToList();
                var convertProperties = TypeDescriptor.GetProperties(GetType()).Cast<PropertyDescriptor>().ToList();



                foreach (var entityProperty in entityProperties)
                {
                    var property = entityProperty;
                    var convertProperty = convertProperties.FirstOrDefault(prop => prop.Name == property.Name);
                    if (convertProperty != null)
                    {
                        convertProperty.SetValue(this, Convert.ChangeType(entityProperty.GetValue(data), convertProperty.PropertyType));
                    }
                }
            }
        }
    }
}
