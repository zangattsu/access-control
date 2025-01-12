using AccessControl.Infra.CrossCutting.Models.Authentication;

namespace AccessControl.Infra.CrossCutting.Interfaces.Services
{
    public interface IUsuarioService
    {
        Task<List<UsuarioModel>> ObterTodosUsuariosAsync();
        //Task<List<UsuarioModel>> ObterUsuariosAsync(BuscarUsuario usuario);
    }
}
