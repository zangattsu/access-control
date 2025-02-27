using System.ComponentModel.DataAnnotations;

namespace CinSaude.Domain.Entities
{
    public class Dependente
    {
        public int DependenteId { get; set; }

        [Required(ErrorMessage = "Informe o Nome do Dependente.")]
        public string Nome { get; set; }

        [DataType(DataType.Date)]
        public DateTime Nascimento { get; set; }

        public string Genero { get; set; }
        public int PacienteId { get; set; }
        public int ParentescoId { get; set; }

        public string Genero_MF
        {
            get
            {
                return Genero == "M" ? "Masculino" : "Feminino";
            }
        }

        public virtual Paciente Paciente { get; set; }
        public virtual Parentesco Parentesco { get; set; }

        public virtual ICollection<ConsultaMedica> ConsultasMedicas { get; set; }
        public ICollection<Vacina> Dependentes { get; set; }
    }
}