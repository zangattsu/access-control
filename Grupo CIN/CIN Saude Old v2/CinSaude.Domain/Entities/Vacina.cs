namespace CinSaude.Domain.Entities
{
    public class Vacina
    {
        public int VacinaId { get; set; }
        public int PacienteId { get; set; }
        public int DependenteId { get; set; }
        public DateTime? Data { get; set; }
        public string Descricao { get; set; }
        public string Local { get; set; }
        public string Observacao { get; set; }

        public virtual Paciente Paciente { get; set; }
        public virtual Dependente Dependente { get; set; }
    }
}