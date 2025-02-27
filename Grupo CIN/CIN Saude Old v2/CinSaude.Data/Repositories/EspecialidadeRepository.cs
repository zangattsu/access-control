using CinSaude.Domain.Entities;
using System.Data.Entity;

namespace CinSaude.Data.Repositories
{
    public class EspecialidadeRepository : GenericRepository<Especialidade>
    {
        internal new DbSet<Especialidade> DbSet;

        public EspecialidadeRepository(DbContext context)
            : base(context)
        {
            DbSet = context.Set<Especialidade>();
        }
    }
}