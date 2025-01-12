namespace AccessControl.Domain.Entities.Authentication
{
    public class Usuario : Entity<Usuario>
    {
        public string NomeUsuario { get; set; } = string.Empty;

        public string SistemaOrigem { get; set; } = string.Empty;

        public int IdTipoUsuario { get; protected set; }

        public virtual Subdominio? TipoUsuario { get; set; }
    }
}