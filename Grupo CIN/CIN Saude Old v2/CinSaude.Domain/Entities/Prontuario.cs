namespace CinSaude.Domain.Entities
{
    public class Prontuario
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public bool Privado { get; set; }
        public int ConsultaId { get; set; }

        public ConsultaMedica ConsultaMedica { get; set; }
    }
}