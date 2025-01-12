using AccessControl.Domain;
using AccessControl.Infra.CrossCutting.Interfaces;
using AccessControl.Infra.CrossCutting.Interfaces.Contexts;
using AccessControl.Infra.CrossCutting.Notifications;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AccessControl.Infra.Data.Repositories
{
    public class RepositoryBase<TEntity, TContext> :
        NotificationTable, IRepositoryBase<TEntity> where TEntity : Entity<TEntity> where TContext : DbContext
    {
        protected readonly DbSet<TEntity> dbSet;
        private bool disposed;
        private readonly IAppDbContextFactory<TContext> _dbContext;
        protected IAppDbContextFactory<TContext> Db;

        public RepositoryBase(IAppDbContextFactory<TContext> DatabaseContext)
        {
            if (DatabaseContext == null)
            {
                throw new ArgumentNullException(nameof(DatabaseContext), @"DatabaseContext cannot be null");
            }

            _dbContext = DatabaseContext;
            var context = _dbContext.CreateDbContext();

            dbSet = context.Set<TEntity>();
            Db = DatabaseContext;
        }

        public TContext Context => _dbContext.CreateDbContext();

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
            var entity = await dbSet.FindAsync(id);
            return entity ?? throw new InvalidOperationException("Entity not found");
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
                Context.Dispose();
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