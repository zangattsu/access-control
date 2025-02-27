namespace CinSaude.Domain.Entities
{
    public class Cidade
    {
        public int CidadeId { get; set; }
        public string Nome { get; set; }

        public ICollection<Paciente> Pacientes { get; set; }
    }
}