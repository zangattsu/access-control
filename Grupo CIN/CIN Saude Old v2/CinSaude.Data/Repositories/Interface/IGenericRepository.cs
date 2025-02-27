using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinSaude.Data.Repositories.Interface
{
    public interface IGenericRepository<TEntity> : IDisposable
    {
        IEnumerable<TEntity> GetAll();
        TEntity Get(object id);
        TEntity Get(object[] keys);
        TEntity Save(TEntity entity);
        TEntity SaveOrUpdate(TEntity entity);
        void Delete(object id);
        void Delete(TEntity entityToDelete);
        void Update(TEntity entityToUpdate);
        TEntity Update(TEntity updated, object key);
    }
}
