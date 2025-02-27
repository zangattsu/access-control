namespace CinSaude.Domain.Entities
{
    public class ResultadoExame
    {
        public int Id { get; set; }
        public int PacienteId { get; set; }
        public int MedicoId { get; set; }
        public int ExameId { get; set; }
        public DateTime? Data { get; set; }
        public string Observacao { get; set; }
        public string UrlArquivo { get; set; }

        public virtual Paciente Paciente { get; set; }
        public virtual Medico Medico { get; set; }
        public virtual Exame Exame { get; set; }
    }
}