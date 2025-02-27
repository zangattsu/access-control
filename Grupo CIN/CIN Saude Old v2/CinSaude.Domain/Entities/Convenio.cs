namespace CinSaude.Domain.Entities
{
    public class Convenio
    {
        public int ConvenioId { get; set; }
        public string Empresa { get; set; }

        public ICollection<Paciente> Pacientes { get; set; }
    }
}