namespace CinSaude.Domain.Entities
{
    public class ClubeDesconto
    {
        public int DescontoId { get; set; }
        public string Empresa { get; set; }

        public ICollection<Paciente> Pacientes { get; set; }
    }
}