using System.Collections.Generic;
using Carsales.Dto.Abstracts;

namespace Carsales.Dto.Common
{
    public class PagedResultDto<TEntity> where TEntity: BaseEntityDto
    {
        public int TotalCount { get; set; }

        public List<TEntity> Results { get; set; }

        public PagedResultDto() 
        {
            Results = new List<TEntity>();
        }

        public PagedResultDto(int count, List<TEntity> results)
        {
            TotalCount = count;
            Results = results;
        }
    }
}
