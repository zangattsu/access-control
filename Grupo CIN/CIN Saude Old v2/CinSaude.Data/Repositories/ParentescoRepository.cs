using CinSaude.Domain.Entities;
using System.Data.Entity;

namespace CinSaude.Data.Repositories
{
    public class ParentescoRepository : GenericRepository<Parentesco>
    {
        internal new DbSet<Parentesco> DbSet;

        public ParentescoRepository(DbContext context)
                    : base(context)
        {
            DbSet = context.Set<Parentesco>();
        }
    }
}