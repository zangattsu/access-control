
using AccessControl.Infra.CrossCutting.Interfaces;
using AccessControl.Infra.CrossCutting.Interfaces.Contexts;
using AccessControl.Infra.CrossCutting.Models;
using AccessControl.Infra.CrossCutting.Notifications;
using AccessControl.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AccessControl.Infra.Data.Repositories
{
    public class RepositoryBase<TEntity, TContext> : NotificationTable, IRepositoryBase<TEntity> where TEntity : Entity<TEntity>
    {
        protected readonly DbSet<TEntity> dbSet;
        private bool disposed;
        private IAppDbContextFactory<TContext> dbContext;
        protected IAppDbContextFactory<DefaultContext> Db;

        public RepositoryBase(IAppDbContextFactory<DefaultContext> DatabaseContext)
        {
            if (DatabaseContext == null)
            {
                throw new ArgumentNullException(nameof(DatabaseContext), @"DatabaseContext cannot be null");
            }

            dbContext = DatabaseContext;
            var context = dbContext.CreateDbContext();

            dbSet = context.Set<TEntity>();
            Db = DatabaseContext;
        }

        public TEntity Get(Guid id)
        {
            return dbSet.Find(id)!;
        }

        public TEntity Get(int id)
        {
            return dbSet.Find(id)!;
        }

        public async Task<TEntity> GetAsync(Guid id)
        {
            return await dbSet.FindAsync(id)!;
        }

        public IEnumerable<TEntity> GetAll()
        {
            IQueryable<TEntity> query = dbSet;
            return query.ToList();
            //return dbSet.ToList();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await dbSet.ToListAsync();
        }

        //TODO: Erro na chamada deste método.
        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return dbSet.Where(predicate).ToList();
        }

        //TODO: Erro na chamada deste método.
        public async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await Task.FromResult(dbSet.Where(predicate).ToList());
        }

        public virtual void Add(TEntity obj)
        {
            dbSet.Add(obj);
        }

        public TEntity AddWithReturn(TEntity obj)
        {
            dbSet.Add(obj);
            return obj;
        }

        public void Update(TEntity obj)
        {
            dbSet.Update(obj);
        }

        public void Remove(Guid obj)
        {
            TEntity entity = Get(obj);

            dbSet.Remove(entity);
        }

        public void Remove(int id)
        {
            TEntity entity = Get(id);

            dbSet.Remove(entity);
        }

        #region IDisposable

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                context.Dispose();
            }

            disposed = true;
        }

        ~RepositoryBase()
        {
            Dispose(false);
        }

        #endregion IDisposable
    }
}