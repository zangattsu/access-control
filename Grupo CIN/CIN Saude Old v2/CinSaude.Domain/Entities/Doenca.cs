using System.ComponentModel.DataAnnotations;

namespace CinSaude.Domain.Entities
{
    public class Doenca
    {
        public int DoencaId { get; set; }

        [Required(ErrorMessage = "Informe o Nome da Doença.")]
        public string Descricao { get; set; }

        [DataType(DataType.Date)]
        public DateTime Data_Diagnostico { get; set; }

        public int PacienteId { get; set; }

        public Paciente Paciente { get; set; }
    }
}