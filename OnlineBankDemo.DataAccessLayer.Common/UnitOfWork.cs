using System;
using System.Collections.Concurrent;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Runtime.Remoting.Contexts;
using System.Threading.Tasks;

namespace OnlineBankDemo.DataAccessLayer.Common
{
    /// <summary>
    /// Класс предназначен для работы разных репозиторий под одним Entity контекстом.
    /// Доступны только операции для получения данных.
    /// </summary>
    public class ReadOnlyUnitOfWork<TContext> : IReadOnlyUnitOfWork<TContext> where TContext : DbContext
    {
        private readonly ConcurrentDictionary<Type, object> _repositories;
        private bool _disposed;

        public ReadOnlyUnitOfWork(IEntityContextFactory factory)
        {
            Context = (TContext)factory.Create(typeof(TContext));
            _repositories = new ConcurrentDictionary<Type, object>();
            _disposed = false;
        }

        public TContext Context { get; }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed) return;

            if (disposing) Context.Dispose();
            _disposed = true;
        }

        public IReadOnlyGenericRepository<TEntity> GetCommonRepository<TEntity>() where TEntity : class
            => _repositories.GetOrAdd(typeof(TEntity), _ => new ReadOnlyGenericRepository<TEntity>(Context)) as IReadOnlyGenericRepository<TEntity>;

        public DbContext GetContext() => Context;
    }
    
    
    public class UnitOfWork<TContext> : ReadOnlyUnitOfWork<TContext>, IUnitOfWork<TContext> where TContext : DbContext
    {
        private readonly ConcurrentDictionary<Type, object> _repositories = new ConcurrentDictionary<Type, object>();

        public UnitOfWork(IEntityContextFactory factory) : base(factory)
        {
        }

        public new IGenericRepository<TEntity> GetCommonRepository<TEntity>() where TEntity : class
            => _repositories.GetOrAdd(typeof(TEntity), _ => new GenericRepository<TEntity>(Context)) as IGenericRepository<TEntity>;

        /// <summary>
        /// Сохранение контекста
        /// </summary>
        public void Save()
        {
            try
            {
                Context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Асинхронное сохранение контекста
        /// </summary>
        public async Task SaveAsync()
        {
            try
            {
                await Context.SaveChangesAsync();
            }
            catch (DbEntityValidationException e)
            {
                throw e;
            }
        }
    }
    
    public class CommonUnitOfWork : UnitOfWork<CommonEntityContext>
    {
        public CommonUnitOfWork(IEntityContextFactory factory) : base(factory)
        {
        }
    }
    
    /// <summary>
    /// Класс предназначен, для работы с Entity контекстом через Reporting базу данных
    /// </summary>
    public class CommonReadOnlyUnitOfWork : ReadOnlyUnitOfWork<CommonEntityContext>
    {
        public CommonReadOnlyUnitOfWork(ReadOnlyEntityContextFactory factory) : base(factory)
        {
        }
    }
}