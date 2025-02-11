using CinSaude.Domain.Entities;
using System.Data.Entity;

namespace CinSaude.Data.Repositories
{
    public class ApplicationMenuRepository : GenericRepository<ApplicationMenu>
    {
        internal DbSet<ApplicationMenu> _dbSet;

        public ApplicationMenuRepository(DbContext context)
            : base(context)
        {
            _dbSet = context.Set<ApplicationMenu>();
        }
    }
}