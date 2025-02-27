using CinSaude.Domain.Entities;
using System.Data.Entity;

namespace CinSaude.Data.Repositories
{
    public class ClubeDescontoRepository : GenericRepository<ClubeDesconto>
    {
        internal new DbSet<ClubeDesconto> DbSet;

        public ClubeDescontoRepository(DbContext context)
                    : base(context)
        {
            DbSet = context.Set<ClubeDesconto>();
        }
    }
}