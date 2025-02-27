using CinSaude.Domain.Entities;
using System.Data.Entity;

namespace CinSaude.Data.Repositories
{
    public class EstadoRepository : GenericRepository<Estado>
    {
        internal new DbSet<Estado> DbSet;

        public EstadoRepository(DbContext context)
                    : base(context)
        {
            DbSet = context.Set<Estado>();
        }
    }
}