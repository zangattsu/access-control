using CinSaude.Domain.Entities.Authentication;
using CinSaude.Domain.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessControl.Infra.CrossCutting.Interfaces.Repository
{
    public interface ITipoUsuarioRepository : IRepositoryBase<TipoUsuario>
    { }
}
