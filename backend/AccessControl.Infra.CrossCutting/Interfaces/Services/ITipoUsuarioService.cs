using CinSaude.Domain.Models.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessControl.Infra.CrossCutting.Interfaces.Services
{
    public interface ITipoUsuarioService
    {
        Task<List<UsuarioModel>> ObterTodosTiposUsuarioAsync();
    }
}
