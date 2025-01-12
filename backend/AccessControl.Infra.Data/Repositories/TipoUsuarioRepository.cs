
using AccessControl.Domain.Entities.Authentication;
using AccessControl.Infra.CrossCutting.Interfaces.Contexts;
using AccessControl.Infra.CrossCutting.Interfaces.Repository;
using AccessControl.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessControl.Infra.Data.Repositories
{
    public class TipoUsuarioRepository : RepositoryBase<TipoUsuario, DefaultContext>, ITipoUsuarioRepository
    {
        public TipoUsuarioRepository(IAppDbContextFactory<DefaultContext> dbContext) : base(dbContext)
        { }
    }
}
