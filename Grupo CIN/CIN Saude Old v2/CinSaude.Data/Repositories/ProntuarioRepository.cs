using CinSaude.Domain.Entities;
using System.Data.Entity;

namespace CinSaude.Data.Repositories
{
    public class ProntuarioRepository : GenericRepository<Prontuario>
    {
        internal new DbSet<Prontuario> DbSet;

        public ProntuarioRepository(DbContext context)
                    : base(context)
        {
            DbSet = context.Set<Prontuario>();
        }
    }
}