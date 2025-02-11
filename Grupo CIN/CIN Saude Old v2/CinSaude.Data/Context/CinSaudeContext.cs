using CinSaude.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CinSaude.Data.Context
{
    public class CinSaudeContext : DbContext
    {
        public CinSaudeContext(DbContextOptions<CinSaudeContext> options) : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("CinSaudeContext");
            }
        }

        public DbSet<ApplicationMenu> ApplicationMenu { get; set; }
    }
}