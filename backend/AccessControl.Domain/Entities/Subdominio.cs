using AccessControl.Domain.Entities.Authentication;

namespace AccessControl.Domain.Entities
{
    public class Subdominio : Entity<Subdominio>
    {
        public string Codigo { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public int IdDominio { get; set; }

        public Dominio Dominio { get; set; } = new Dominio();
        public List<Usuario> Usuarios { get; set; } = new List<Usuario>();

        public Subdominio(string codigo, string descricao, int idDominio, Dominio dominio)
        {
            Codigo = codigo;
            Descricao = descricao;
            IdDominio = idDominio;
            Dominio = dominio;
        }
    }
}