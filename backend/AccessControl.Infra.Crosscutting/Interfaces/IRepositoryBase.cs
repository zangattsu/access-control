using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AccessControl.Infra.CrossCutting.Interfaces
{
    public interface IRepositoryBase<TEntity> : INotificationTable, IDisposable where TEntity : class
    {
        /// <summary>
        ///     Gets entity (of type) from repository based on given ID
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Entity</returns>
        TEntity Get(Guid id);
        TEntity Get(int id);

        /// <summary>
        ///     Asynchronously gets entity (of type) from repository based on given ID
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<TEntity> GetAsync(Guid id);

        /// <summary>
        ///     Gets all entities of type from repository
        /// </summary>
        /// <returns></returns>
        IEnumerable<TEntity> GetAll();

        /// <summary>
        ///     Asynchronously gets all entities of type from repository
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<TEntity>> GetAllAsync();

        /// <summary>
        ///     Finds all entities of type which match given predicate
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns>Entities which satisfy conditions</returns>
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate);



        void Add(TEntity obj);
        TEntity AddWithReturn(TEntity obj);
        void Update(TEntity obj);
        void Remove(Guid obj);
        void Remove(int id);
    }
}
