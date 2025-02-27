using CinSaude.Domain.Entities;
using System.Data.Entity;

namespace CinSaude.Data.Repositories
{
    public class MedicamentoRepository : GenericRepository<Medicamento>
    {
        internal new DbSet<Medicamento> DbSet;

        public MedicamentoRepository(DbContext context)
            : base(context)
        {
            DbSet = context.Set<Medicamento>();
        }
    }
}