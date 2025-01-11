
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
    public class TipoUsuarioRepository : RepositoryBase<TipoUsuario>, ITipoUsuarioRepository
    {
        private readonly IAppDbContextFactory<DefaultContext> _contextFactory;

        public TipoUsuarioRepository(IAppDbContextFactory<DefaultContext> contextFactory) : base(contextFactory)
        {
            _context = context;
        }
    }
}
