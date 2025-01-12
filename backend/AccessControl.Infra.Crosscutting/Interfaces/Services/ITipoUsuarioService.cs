using AccessControl.Infra.CrossCutting.Models.Authentication;

namespace AccessControl.Infra.CrossCutting.Interfaces.Services
{
    public interface ITipoUsuarioService
    {
        Task<List<UsuarioModel>> ObterTodosTiposUsuarioAsync();
    }
}
