namespace CinSaude.Domain.Entities
{
    public class Estado
    {
        public int EstadoId { get; set; }
        public string Nome { get; set; }

        public ICollection<Medico> Medicos { get; set; }
        public ICollection<Paciente> Pacientes { get; set; }
    }
}