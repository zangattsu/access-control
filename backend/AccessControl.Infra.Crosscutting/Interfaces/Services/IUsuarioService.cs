using AccessControl.Infra.CrossCutting.Models.Authentication;
using CinSaude.Domain.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessControl.Infra.CrossCutting.Interfaces.Services
{
    public interface IUsuarioService
    {
        Task<List<UsuarioModel>> ObterTodosUsuariosAsync();
        Task<List<UsuarioModel>> ObterUsuariosAsync(BuscarUsuario usuario);
    }
}
