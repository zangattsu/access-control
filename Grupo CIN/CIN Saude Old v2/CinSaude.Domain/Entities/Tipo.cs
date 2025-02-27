namespace CinSaude.Domain.Entities
{
    public class Tipo
    {
        public int TipoId { get; set; }
        public string Descricao { get; set; }

        public ICollection<Medico> Medicos { get; set; }
    }
}