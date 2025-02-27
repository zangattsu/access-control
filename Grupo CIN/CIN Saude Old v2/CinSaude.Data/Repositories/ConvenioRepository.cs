using CinSaude.Domain.Entities;
using System.Data.Entity;

namespace CinSaude.Data.Repositories
{
    public class ConvenioRepository : GenericRepository<Convenio>
    {
        internal new DbSet<Convenio> DbSet;

        public ConvenioRepository(DbContext context)
                    : base(context)
        {
            DbSet = context.Set<Convenio>();
        }
    }
}