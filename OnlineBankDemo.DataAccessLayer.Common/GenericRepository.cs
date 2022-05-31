using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;

namespace OnlineBankDemo.DataAccessLayer.Common
{
    public class ReadOnlyGenericRepository<TEntity> : IReadOnlyGenericRepository<TEntity> where TEntity:class
    {
        protected readonly DbContext Entities;

        protected DbSet<TEntity> EntityDbSet => Entities.Set<TEntity>();

        public DbContext Context => Entities;

        public ReadOnlyGenericRepository(DbContext context)
        {
            Entities = context;
        }

        /// <inheritdoc />
        public virtual IQueryable<TEntity> GetAll()
        {
            return EntityDbSet;
        }

        /// <inheritdoc />
        public IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate)
        {
            return EntityDbSet.Where(predicate);
        }

        /// <inheritdoc />
        public TEntity FindByKey(params object[] keyValues)
        {
            return EntityDbSet.Find(keyValues);
        }

        /// <inheritdoc />
        public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return EntityDbSet.FirstOrDefault(predicate);
        }

        /// <inheritdoc />
        public TEntity GetFirst(Expression<Func<TEntity, bool>> predicate, string ifNullErrorMessage = "")
        {
            var item = FirstOrDefault(predicate);
            if (item == null)
                throw new Exception(string.IsNullOrEmpty(ifNullErrorMessage) ? "Не удалось получить ни одного значения" : ifNullErrorMessage);
            return item;
        }
    } 
    
    public class GenericRepository<TEntity> : ReadOnlyGenericRepository<TEntity>, IGenericRepository<TEntity> where TEntity : class
    {
        public GenericRepository(DbContext context) : base(context)
        {
        }

        public virtual TEntity Add(TEntity entity)
        {
            return EntityDbSet.Add(entity);
        }

        public virtual void AddRange(IEnumerable<TEntity> entities)
        {
            EntityDbSet.AddRange(entities);
        }

        public virtual void Delete(TEntity entity)
        {
            EntityDbSet.Remove(entity);
        }

        public virtual void DeleteRange(IEnumerable<TEntity> entities)
        {
            EntityDbSet.RemoveRange(entities);
        }

        public virtual TEntity Edit(TEntity entity)
        {
            Entities.Entry(entity).State = EntityState.Modified;
            return entity;
        }

        public virtual void EditRange(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                Edit(entity);
            }
        }

        public TEntity Attach(TEntity entity)
        {
            return EntityDbSet.Attach(entity);
        }

        public virtual void Save()
        {
            try
            {
                Entities.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                throw e;
            }
            catch (DbUpdateException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <inheritdoc />
        public void DetachAll(EntityState? state = null)
        {
            foreach (var entry in Context.ChangeTracker.Entries<TEntity>())
                if (state == null || state.Value.HasFlag(entry.State))
                    entry.State = EntityState.Detached;
        }
    }
}