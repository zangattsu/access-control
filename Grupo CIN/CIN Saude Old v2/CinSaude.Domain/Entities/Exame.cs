using System.ComponentModel.DataAnnotations;

namespace CinSaude.Domain.Entities
{
    public class Exame
    {
        public int ExameId { get; set; }

        [Required(ErrorMessage = "Informe o Nome do Exame.")]
        public string Descricao { get; set; }

        public string CodigoConvenio { get; set; }
        public int PacienteId { get; set; }
        public string UrlArquivo { get; set; }

        public virtual Paciente Paciente { get; set; }
        public virtual ICollection<ResultadoExame> ResultadosDeExames { get; set; }
    }
}