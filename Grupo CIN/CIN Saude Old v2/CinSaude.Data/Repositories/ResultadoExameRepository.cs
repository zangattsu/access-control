using CinSaude.Domain.Entities;
using System.Data.Entity;

namespace CinSaude.Data.Repositories
{
    public class ResultadoExameRepository : GenericRepository<ResultadoExame>
    {
        internal new DbSet<ResultadoExame> DbSet;

        public ResultadoExameRepository(DbContext context)
                    : base(context)
        {
            DbSet = context.Set<ResultadoExame>();
        }
    }
}