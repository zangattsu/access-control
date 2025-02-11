using Microsoft.EntityFrameworkCore.SqlServer; // Add this using directive
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CinSaude.Domain.Entities;

namespace CinSaude.Data.Context
{
    public class CinSaudeContext : DbContext
    {
        public CinSaudeContext(DbContextOptions<CinSaudeContext> options) : base(options)
        {
        }

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
