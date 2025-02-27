namespace CinSaude.Domain.Entities
{
    public class ConsultaMedica
    {
        public int Id { get; set; }
        public int PacienteId { get; set; }
        public DateTime? Data { get; set; }
        public int MedicoId { get; set; }
        public string Observacao { get; set; }
        public int DependenteId { get; set; }
        public string UrlArquivo { get; set; }

        public virtual Paciente Paciente { get; set; }
        public virtual Medico Medico { get; set; }
        public virtual Dependente Dependente { get; set; }

        public virtual ICollection<Prontuario> Prontuarios { get; set; } = new List<Prontuario>();
        public virtual ICollection<Exame> Exames { get; set; } = new List<Exame>();
    }
}