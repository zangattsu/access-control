using AccessControl.Domain.Entities;
using AccessControl.Infra.CrossCutting.Interfaces.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace AccessControl.ORM
{
    public class DefaultContext : DbContext, IAppDefaultContext<DefaultContext>
    {
        public DefaultContext(DbContextOptions<DefaultContext> options) : base(options)
        {
            Users = Set<User>();
        }

        // Defina seus DbSets aqui
        public DbSet<User> Users { get; set; }
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