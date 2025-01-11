namespace AccessControl.Domain.Entities
{
    public class Dominio : Entity<Dominio>
    {
        public string Codigo { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public List<Subdominio> Subdominos { get; set; } = new List<Subdominio>();
    }
}