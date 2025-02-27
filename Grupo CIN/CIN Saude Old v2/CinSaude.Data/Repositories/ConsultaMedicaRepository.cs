using CinSaude.Domain.Entities;
using System.Data.Entity;

namespace CinSaude.Data.Repositories
{
    public class ConsultaMedicaRepository : GenericRepository<ConsultaMedica>
    {
        internal new DbSet<ConsultaMedica> DbSet;

        public ConsultaMedicaRepository(DbContext context)
                    : base(context)
        {
            DbSet = context.Set<ConsultaMedica>();
        }
    }
}