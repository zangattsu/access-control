using AccessControl.Domain.Entities.Authentication;
using AccessControl.Infra.CrossCutting.Interfaces.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AccessControl.Infra.Data.Context
{
    public class DefaultContext : DbContext, IAppDefaultContext<DefaultContext>
    {
        public DefaultContext(DbContextOptions<DefaultContext> options) : base(options)
        { }

        // Defina seus DbSets aqui
        public DbSet<Usuario> Usuarios { get; set; }
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