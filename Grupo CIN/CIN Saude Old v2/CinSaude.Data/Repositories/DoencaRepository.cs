using CinSaude.Domain.Entities;
using System.Data.Entity;

namespace CinSaude.Data.Repositories
{
    public class DoencaRepository : GenericRepository<Doenca>
    {
        internal new DbSet<Doenca> DbSet;

        public DoencaRepository(DbContext context)
            : base(context)
        {
            DbSet = context.Set<Doenca>();
        }
    }
}