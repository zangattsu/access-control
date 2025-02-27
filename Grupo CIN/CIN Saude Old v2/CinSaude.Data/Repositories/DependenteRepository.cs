using CinSaude.Domain.Entities;
using System.Data.Entity;

namespace CinSaude.Data.Repositories
{
    public class DependenteRepository : GenericRepository<Dependente>
    {
        internal new DbSet<Dependente> DbSet;

        public DependenteRepository(DbContext context)
            : base(context)
        {
            DbSet = context.Set<Dependente>();
        }
    }
}