using CinSaude.Data.Repositories.Interface;
using System.Data.Entity;
using System.Data.Entity.Migrations;

namespace CinSaude.Data.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        internal DbContext Context;
        internal DbSet<TEntity> DbSet;

        public GenericRepository(DbContext context)
        {
            Context = context;
            DbSet = context.Set<TEntity>();
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            IQueryable<TEntity> query = DbSet;
            return query.ToList();
        }

        public virtual TEntity Get(object id)
        {
            return DbSet.Find(id);
        }

        public virtual TEntity Get(object[] keys)
        {
            return DbSet.Find(keys);
        }

        public virtual TEntity SaveOrUpdate(TEntity entity)
        {
            DbSet.AddOrUpdate(entity);
            Context.SaveChanges();

            return entity;
        }

        public virtual TEntity Save(TEntity entity)
        {
            DbSet.Add(entity);
            Context.SaveChanges();

            return entity;
        }

        public virtual void Delete(object id)
        {
            TEntity entityToDelete = DbSet.Find(id);
            Delete(entityToDelete);
            Context.SaveChanges();
        }

        public virtual void Delete(TEntity entityToDelete)
        {
            if (Context.Entry(entityToDelete).State == EntityState.Detached)
            {
                DbSet.Attach(entityToDelete);
            }
            DbSet.Remove(entityToDelete);
            Context.SaveChanges();
        }

        public virtual void Update(TEntity entityToUpdate)
        {
            Context.Entry(entityToUpdate).State = EntityState.Modified;
            Context.SaveChanges();
        }

        public TEntity Update(TEntity updated, object key)
        {
            if (updated == null)
                return null;

            TEntity existing = Context.Set<TEntity>().Find(key);

            if (existing != null)
            {
                Context.Entry(existing).CurrentValues.SetValues(updated);
                Context.SaveChanges();
            }
            return existing;
        }

        void IDisposable.Dispose()
        {
            if (Context.Database.Connection.State == System.Data.ConnectionState.Open)
            {
                Context.Database.Connection.Close();
            }

            Context.Dispose();
            Context = null;
            DbSet = null;
        }
    }
}