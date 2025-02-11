using CinSaude.Domain.Entities;
using System.Data.Entity;

namespace CinSaude.Data.Repositories
{
    public class TipoRepository : GenericRepository<Tipo>
    {
        internal new DbSet<Tipo> DbSet;

        public TipoRepository(DbContext context)
                    : base(context)
        {
            DbSet = context.Set<Tipo>();
        }
    }
}