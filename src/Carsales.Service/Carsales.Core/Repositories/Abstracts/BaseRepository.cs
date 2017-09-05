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
        IQueryable<TModel> GetAll();
        TModel Get(TKey id);
        Task<TModel> GetAsync(TKey id);
        IQueryable<TModel> FindBy(Expression<Func<TModel, bool>> predicate);
        TModel Add(TModel entity);
        TModel Delete(TModel entity);
        void Edit(TModel entity);
        void Save();
        Task SaveAsync();
    }

    public interface IRepository<TModel> : IRepository<TModel, long> 
        where TModel : BaseEntity<long>
    {

    }

    public abstract class BaseRepository<TModel, TKey> : IRepository<TModel, TKey> 
        where TModel : BaseEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        protected DbContext DbContext;
        protected readonly DbSet<TModel> Dbset;

        protected BaseRepository(DbContext context)
        {
            DbContext = context;
            Dbset = context.Set<TModel>();
        }

        public virtual IQueryable<TModel> GetAll()
        {
            return Dbset.AsNoTracking();
        }

        public async Task<TModel> GetAsync(TKey id)
        {
            return await Dbset.FindAsync(id);
        }

        public TModel Get(TKey id)
        {
            return Dbset.Find(id);
        }

        public IQueryable<TModel> FindBy(System.Linq.Expressions.Expression<Func<TModel, bool>> predicate)
        {
            var query = Dbset.Where(predicate);
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
            DbContext.Entry(entity).State = System.Data.Entity.EntityState.Modified;
        }


        public virtual void Save()
        {
            DbContext.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await DbContext.SaveChangesAsync();
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
