using System.ComponentModel.DataAnnotations;

namespace CinSaude.Domain.Entities
{
    public class Medicamento
    {
        public int MedicamentoId { get; set; }

        [Required(ErrorMessage = "Informe o Nome do Remédio ou Genérico.")]
        public string Nome { get; set; }

        [DataType(DataType.Date)]
        public DateTime Data_Inicio { get; set; }

        public string Em_Uso { get; set; }
        public string Dosagem { get; set; }
        public string Prazo { get; set; }
        public string Uso_Continuo { get; set; }
        public int PacienteId { get; set; }
        public bool Publico { get; set; }

        public string EmUso
        {
            get
            {
                return Em_Uso == "S" ? "Sim" : "Não";
            }
        }

        public Paciente Paciente { get; set; }
    }
}