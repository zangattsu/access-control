using CinSaude.Domain.Entities;
using System.Data.Entity;

namespace CinSaude.Data.Repositories
{
    public class ExameRepository : GenericRepository<Exame>
    {
        internal new DbSet<Exame> DbSet;

        public ExameRepository(DbContext context)
            : base(context)
        {
            DbSet = context.Set<Exame>();
        }
    }
}