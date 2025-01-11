using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessControl.Infra.CrossCutting.Interfaces.Contexts
{
    public interface IAppDefaultContext<out TContext> where TContext : DbContext
    { }

    public interface IAppDbContextFactory<out TContext> where TContext : DbContext
    {
        TContext CreateDbContext();
    }
}
