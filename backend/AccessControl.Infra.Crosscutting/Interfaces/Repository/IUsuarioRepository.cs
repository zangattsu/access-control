
using AccessControl.Domain.Entities.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessControl.Infra.CrossCutting.Interfaces.Repository
{
    public interface IUsuarioRepository : IRepositoryBase<Usuario>
    {
        Task<IList<Usuario>> ObterUsuario(BuscarUsuario filtroUsuario);
    }
}
