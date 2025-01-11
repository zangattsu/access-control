using AccessControl.Infra.CrossCutting.Models;

namespace AccessControl.Domain.Entities.Authentication
{
    public class TipoUsuario : Entity<TipoUsuario>
    {
        public string NomeTipoUsuario { get; set; }

        public List<Usuario> Usuarios { get; set; }

        public TipoUsuario(string nomeTipoUsuario)
        {
            NomeTipoUsuario = nomeTipoUsuario;
            Usuarios = new();
        }
    }
}