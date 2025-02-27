using System.ComponentModel.DataAnnotations;

namespace CinSaude.Domain.Entities
{
    public class Paciente
    {
        public int PacienteId { get; set; }

        [Required(ErrorMessage = "Informe o Nome do Médico.")]
        [Display(Name = "Nome :")]
        public string Nome { get; set; }

        [DataType(DataType.Date)]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [Display(Name = "Data Nascimento :")]
        public DateTime DataNascimento { get; set; }

        [Display(Name = "Email :")]
        public string EMail { get; set; }

        [Display(Name = "CPF : (digite apenas os números)")]
        public string Cpf { get; set; }

        public string Genero { get; set; }

        public string Status { get; set; }

        public string TipoSanguineo { get; set; }
        public int DoadorOrgaos { get; set; }
        public int RecebeuTransfusao10Anos { get; set; }
        public int AtividadeFisica { get; set; }
        public int BebidasAlcoolicas { get; set; }
        public int Fumante { get; set; }

        public DateTime? DataCadastro { get; set; }

        public int? Qt_Dependentes { get; set; }

        //public int CidadeId { get; set; }

        [Display(Name = "Cidade :")]
        public string Cidade { get; set; }

        [Display(Name = "Outro :")]
        public string Outro_Convenio { get; set; }

        [Required(ErrorMessage = "Informe o Estado.")]
        public int EstadoId { get; set; }

        public virtual Estado Estado { get; set; }

        public ICollection<Exame> Exames { get; set; }
        public ICollection<Medicamento> Medicamentos { get; set; }
        public ICollection<Doenca> Doencas { get; set; }
        public ICollection<Dependente> Dependentes { get; set; }
        public virtual ICollection<ResultadoExame> ResultadosDeExames { get; set; }

        public virtual ICollection<ConsultaMedica> ConsultasMedicas { get; set; }

        public int ConvenioId { get; set; }

        public virtual Convenio Convenio { get; set; }

        public int? DescontoId { get; set; }

        public virtual ClubeDesconto ClubeDesconto { get; set; }

        public string Genero_MF
        {
            get
            {
                return Genero == "M" ? "Masculino" : "Feminino";
            }
        }
    }
}