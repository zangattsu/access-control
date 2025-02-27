namespace CinSaude.Domain.Entities
{
    public class ConsultaExame
    {
        public int ConsultaId { get; set; }
        public int ExameId { get; set; }
        public string UrlArquivo { get; set; } = string.Empty;

        public virtual required ConsultaMedica ConsultaMedica { get; set; }
        public virtual ICollection<Exame> Exames { get; set; } = new List<Exame>();
    }
}