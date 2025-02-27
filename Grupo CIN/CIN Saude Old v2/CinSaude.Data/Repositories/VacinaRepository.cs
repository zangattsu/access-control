using CinSaude.Domain.Entities;
using System.Data.Entity;

namespace CinSaude.Data.Repositories
{
    public class VacinaRepository : GenericRepository<Vacina>
    {
        internal new DbSet<Vacina> DbSet;

        public VacinaRepository(DbContext context)
                    : base(context)
        {
            DbSet = context.Set<Vacina>();
        }
    }
}