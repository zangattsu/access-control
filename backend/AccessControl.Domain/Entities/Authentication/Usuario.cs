using AccessControl.Infra.CrossCutting.Interfaces.Repository;
using AccessControl.Infra.CrossCutting.Models;

namespace AccessControl.Domain.Entities.Authentication
{
    public class Usuario : Entity<Usuario>
    {
        private ISubdominioRepository _subdominioRepository { get; }

        public string NomeUsuario { get; set; }

        public string SistemaOrigem { get; set; }

        public int IdTipoUsuario { get; protected set; }

        public virtual Subdominio TipoUsuario { get; set; }

        public Usuario(
            string nomeUsuario,
            string sistemaOrigem,
            int idTipoUsuario,
            ISubdominioRepository subdominioRepository)
        {
            NomeUsuario = nomeUsuario;
            SistemaOrigem = sistemaOrigem;
            IdTipoUsuario = idTipoUsuario;

            _subdominioRepository = subdominioRepository;
            TipoUsuario = ObterSubdominio(IdTipoUsuario);
        }

        private Subdominio ObterSubdominio(int idTipoUsuario)
        {
            return _subdominioRepository.Get(idTipoUsuario);
        }
    }
}