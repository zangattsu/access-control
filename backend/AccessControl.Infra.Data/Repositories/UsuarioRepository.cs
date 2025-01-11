using AspNetCore.IQueryable.Extensions;
using CinSaude.Data.Context;
using CinSaude.Domain.Entities.Authentication;
using CinSaude.Domain.Filters;
using CinSaude.Domain.Interfaces.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AccessControl.Infra.Data.Repositories
{
    public class UsuarioRepository : RepositoryBase<Usuario>, IUsuarioRepository
    {
        private readonly CinSaudeContext _context;
        public UsuarioRepository(CinSaudeContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IList<Usuario>> ObterUsuario(BuscarUsuario filtroUsuario)
        {
            var usuarios = await _context.Usuarios.AsQueryable().Apply(filtroUsuario).ToListAsync();
            return usuarios;
        }
    }
}