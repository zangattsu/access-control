using AccessControl.Domain.Entities.Authentication;

namespace AccessControl.Domain.Entities
{
    public class Subdominio : Entity<Subdominio>
    {
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public int IdDominio { get; set; }

        public Dominio Dominio { get; set; }

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