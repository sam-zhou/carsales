using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Carsales.Core.Models.Abstracts;

namespace Carsales.Core.Repositories.Abstracts
{
    public interface IRepository
    {
        
    }


    public interface IRepository<TModel, in TKey> : IRepository 
        where TModel : BaseEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        IEnumerable<TModel> GetAll();
        TModel Get(TKey id);
        IEnumerable<TModel> FindBy(Expression<Func<TModel, bool>> predicate);
        TModel Add(TModel entity);
        TModel Delete(TModel entity);
        void Edit(TModel entity);
        void Save();
    }

    public interface IRepository<TModel> : IRepository<TModel, long> 
        where TModel : BaseEntity<long>
    {

    }

    public abstract class BaseRepository<TModel, TKey> : IRepository<TModel, TKey> 
        where TModel : BaseEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        protected DbContext Entities;
        protected readonly IDbSet<TModel> Dbset;

        protected BaseRepository(DbContext context)
        {
            Entities = context;
            Dbset = context.Set<TModel>();
        }

        public virtual IEnumerable<TModel> GetAll()
        {

            return Dbset.AsEnumerable();
        }

        public TModel Get(TKey id)
        {
            return Dbset.Find(id);
        }

        public IEnumerable<TModel> FindBy(System.Linq.Expressions.Expression<Func<TModel, bool>> predicate)
        {

            IEnumerable<TModel> query = Dbset.Where(predicate).AsEnumerable();
            return query;
        }

        public virtual TModel Add(TModel entity)
        {
            return Dbset.Add(entity);
        }

        public virtual TModel Delete(TModel entity)
        {
            return Dbset.Remove(entity);
        }

        public virtual void Edit(TModel entity)
        {
            Entities.Entry(entity).State = System.Data.Entity.EntityState.Modified;
        }

        public virtual void Save()
        {
            Entities.SaveChanges();
        }

        
    }

    public abstract class BaseRepository<TModel> : BaseRepository<TModel, long>
        where TModel : BaseEntity<long>
    {
        protected BaseRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
