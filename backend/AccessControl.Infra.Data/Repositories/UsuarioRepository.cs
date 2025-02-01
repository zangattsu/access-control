using AccessControl.Domain.Entities.Authentication;
using AccessControl.Infra.CrossCutting.Interfaces.Contexts;
using AccessControl.Infra.CrossCutting.Interfaces.Repository;
using AccessControl.Infra.CrossCutting.Models;
using AccessControl.Infra.Data.Context;
using AspNetCore.IQueryable.Extensions;
using Microsoft.EntityFrameworkCore;

namespace AccessControl.Infra.Data.Repositories
{
    public class UsuarioRepository : RepositoryBase<Usuario, DefaultContext>, IUsuarioRepository
    {
        public UsuarioRepository(IAppDbContextFactory<DefaultContext> dbContext) : base(dbContext)
        { }

        public async Task<IList<Usuario>> ObterUsuario(BuscarUsuario filtroUsuario)
        {
            var usuarios = await Context.Usuarios
                .AsQueryable()
                .Apply(filtroUsuario)
                .ToListAsync();

            return usuarios;
        }
    }
}