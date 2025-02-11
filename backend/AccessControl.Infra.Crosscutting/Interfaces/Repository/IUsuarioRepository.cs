
using AccessControl.Domain.Entities.Authentication;
using AccessControl.Infra.CrossCutting.Models;

namespace AccessControl.Infra.CrossCutting.Interfaces.Repository
{
    public interface IUsuarioRepository : IRepositoryBase<Usuario>
    {
        Task<IList<Usuario>> ObterUsuario(BuscarUsuario filtroUsuario);
    }
}
