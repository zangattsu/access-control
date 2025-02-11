using CinSaude.Domain.Entities;
using System.Data.Entity;

namespace CinSaude.Data.Repositories
{
    public class MedicoRepository : GenericRepository<Medico>
    {
        internal new DbSet<Medico> DbSet;

        public MedicoRepository(DbContext context)
            : base(context)
        {
            DbSet = context.Set<Medico>();
        }
    }
}