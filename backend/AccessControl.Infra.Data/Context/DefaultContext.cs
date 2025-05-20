using AccessControl.Domain.Entities.Authentication;
using AccessControl.Infra.CrossCutting.Interfaces.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace AccessControl.Infra.Data.Context
{
    public class DefaultContext : DbContext, IAppDefaultContext<DefaultContext>
    {
        public DefaultContext(DbContextOptions<DefaultContext> options) : base(options)
        {
            Usuarios = Set<User>();
        }

        // Defina seus DbSets aqui
        public DbSet<User> Usuarios { get; set; }
    }

    public class FinanceiroContextFactory : IAppDbContextFactory<DefaultContext>
    {
        private readonly IConfiguration _configuration;

        public FinanceiroContextFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public DefaultContext CreateDbContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<DefaultContext>();
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));

            return new DefaultContext(optionsBuilder.Options);
        }
    }
}